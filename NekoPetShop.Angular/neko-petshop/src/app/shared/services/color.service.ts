import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Color } from '../models/color.model';
import { FilteredList } from '../../shared/models/filteredList.model';


@Injectable({ providedIn: 'root' })
export class ColorService {
  private apiUrl = 'http://neko-petshop.azurewebsites.net/api/colors';

  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  constructor(private http: HttpClient) { }

  /** GET all colors */
  getAllColors(): Observable<Color[]> {
    return this.http.get<Color[]>(this.apiUrl)
  }

  /** GET filtered colors */
  getColors(currentPage: number, itemsPerPage: number, animalType: number, sortType: number, orderByType: number ): Observable<FilteredList<Color>> {
    const params = new HttpParams()
      .set('currentPage', currentPage.toString())
      .set('itemsPerPage', itemsPerPage.toString())
      .set('animalType', animalType.toString())
      .set('sortType', sortType.toString())
      .set('orderByType', orderByType.toString());
    return this.http.get<FilteredList<Color>>(this.apiUrl, {params: params});
  }

  /** GET color by id. Return `undefined` when id not found */
  getColorNo404<Data>(id: number): Observable<Color> {
    const url = `${this.apiUrl}/?id=${id}`;
    return this.http.get<Color[]>(url)
      .pipe(
        map(colors => colors[0]), 
        tap(c => {
          const outcome = c ? `fetched` : `did not find`;
        }),
        catchError(this.handleError<Color>(`getColor id=${id}`))
      );
  }

  /** GET color by id. Will 404 if id not found */
  getColor(id: number): Observable<Color> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Color>(url).pipe(
      catchError(this.handleError<Color>(`getColor id=${id}`))
    );
  }

  /* GET colors whose name contains search term */
  searchColor(term: string): Observable<Color[]> {
    if (!term.trim()) {
      return of([]);
    }
    return this.http.get<Color[]>(`${this.apiUrl}/?name=${term}`).pipe(
      catchError(this.handleError<Color[]>('searchColors', []))
    );
  }

  /** POST: add a new color to the server */
  addColor (color: Color): Observable<Color> {
    return this.http.post<Color>(this.apiUrl, color, this.httpOptions).pipe(
      tap((newColor: Color) =>
      catchError(this.handleError<Color>('addColor'))
    ));
  }

  /** DELETE: delete the color from the server */
  deleteColor (color: Color | number): Observable<Color> {
    const id = typeof color === 'number' ? color : color.id;
    const url = `${this.apiUrl}/${id}`;

    return this.http.delete<Color>(url, this.httpOptions).pipe(
      catchError(this.handleError<Color>('deleteColor'))
    );
  }

  /** PUT: update the color on the server */
  updateColor (color: Color,id: number ): Observable<Color> {
    debugger;
    const url = `${this.apiUrl}/${id}`;

    return this.http.put<Color>(url, color, this.httpOptions).pipe(
      catchError(this.handleError<any>('updateColor'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
