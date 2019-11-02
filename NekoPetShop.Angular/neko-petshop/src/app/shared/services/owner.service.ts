import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Owner } from '../models/owner.model';
import { FilteredList } from '../../shared/models/filteredList.model';


@Injectable({ providedIn: 'root' })
export class OwnerService {
  private apiUrl = 'http://neko-petshop.azurewebsites.net/api/owners';

  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  constructor(private http: HttpClient) { }

  /** GET all owners */
  getAllOwners(): Observable<Owner[]> {
    return this.http.get<Owner[]>(this.apiUrl)
  }

  /** GET filtered owners */
  getOwners(currentPage: number, itemsPerPage: number, animalType: number, sortType: number, orderByType: number ): Observable<FilteredList<Owner>> {
    const params = new HttpParams()
      .set('currentPage', currentPage.toString())
      .set('itemsPerPage', itemsPerPage.toString())
      .set('animalType', animalType.toString())
      .set('sortType', sortType.toString())
      .set('orderByType', orderByType.toString());
    return this.http.get<FilteredList<Owner>>(this.apiUrl, {params: params});
  }

  /** GET owner by id. Return `undefined` when id not found */
  getOwnerrNo404<Data>(id: number): Observable<Owner> {
    const url = `${this.apiUrl}/?id=${id}`;
    return this.http.get<Owner[]>(url)
      .pipe(
        map(owners => owners[0]), 
        tap(c => {
          const outcome = c ? `fetched` : `did not find`;
        }),
        catchError(this.handleError<Owner>(`getOwner id=${id}`))
      );
  }

  /** GET owner by id. Will 404 if id not found */
  getOwner(id: number): Observable<Owner> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Owner>(url).pipe(
      catchError(this.handleError<Owner>(`getOwner id=${id}`))
    );
  }

  /* GET owners whose name contains search term */
  searchOwner(term: string): Observable<Owner[]> {
    if (!term.trim()) {
      return of([]);
    }
    return this.http.get<Owner[]>(`${this.apiUrl}/?name=${term}`).pipe(
      catchError(this.handleError<Owner[]>('searchOwners', []))
    );
  }

  /** POST: add a new owner to the server */
  addOwner (owner: Owner): Observable<Owner> {
    return this.http.post<Owner>(this.apiUrl, owner, this.httpOptions).pipe(
      tap((newOwner: Owner) =>
      catchError(this.handleError<Owner>('addOwner'))
    ));
  }

  /** DELETE: delete the owner from the server */
  deleteOwner (owner: Owner | number): Observable<Owner> {
    const id = typeof owner === 'number' ? owner : owner.id;
    const url = `${this.apiUrl}/${id}`;

    return this.http.delete<Owner>(url, this.httpOptions).pipe(
      catchError(this.handleError<Owner>('deleteOwner'))
    );
  }

  /** PUT: update the owner on the server */
  updateOwner (owner: Owner,id: number ): Observable<Owner> {
    debugger;
    const url = `${this.apiUrl}/${id}`;

    return this.http.put<Owner>(url, owner, this.httpOptions).pipe(
      catchError(this.handleError<any>('updateOwner'))
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
