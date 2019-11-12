import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Pet } from './pet.model';
import { FilteredList } from '../../shared/models/filteredList.model';



@Injectable({ providedIn: 'root' })
export class PetService {
  private apiUrl = 'http://neko-petshop.azurewebsites.net/api/pets';

  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  constructor(private http: HttpClient) { }

  /** GET all pets */
  getAllPets(): Observable<FilteredList<Pet[]>> {
    return this.http.get<FilteredList<Pet[]>>(this.apiUrl)
  }

  /** GET filtered pets */
  getPets(currentPage: number, itemsPerPage: number, animalType: number, sortType: number, orderByType: number ): Observable<FilteredList<Pet>> {
    const params = new HttpParams()
      .set('currentPage', currentPage.toString())
      .set('itemsPerPage', itemsPerPage.toString())
      .set('animalType', animalType.toString())
      .set('sortType', sortType.toString())
      .set('orderByType', orderByType.toString());
    return this.http.get<FilteredList<Pet>>(this.apiUrl, {params: params});
  }

  /** GET pet by id. Return `undefined` when id not found */
  getPetNo404<Data>(id: number): Observable<Pet> {
    const url = `${this.apiUrl}/?id=${id}`;
    return this.http.get<Pet[]>(url)
      .pipe(
        map(pets => pets[0]), 
        tap(p => {
          const outcome = p ? `fetched` : `did not find`;
        }),
        catchError(this.handleError<Pet>(`getPet id=${id}`))
      );
  }

  /** GET pet by id. Will 404 if id not found */
  getPet(id: number): Observable<Pet> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Pet>(url).pipe(
      catchError(this.handleError<Pet>(`getPet id=${id}`))
    );
  }

  /* GET pets whose name contains search term */
  searchPet(term: string): Observable<Pet[]> {
    if (!term.trim()) {
      return of([]);
    }
    return this.http.get<Pet[]>(`${this.apiUrl}/?name=${term}`).pipe(
      catchError(this.handleError<Pet[]>('searchPets', []))
    );
  }

  /** POST: add a new pet to the server */
  addPet (pet: Pet): Observable<Pet> {
    return this.http.post<Pet>(this.apiUrl, pet, this.httpOptions).pipe(
      tap((newPet: Pet) =>
      catchError(this.handleError<Pet>('addPet'))
    ));
  }

  /** DELETE: delete the pet from the server */
  deletePet (pet: Pet | number): Observable<Pet> {
    const id = typeof pet === 'number' ? pet : pet.id;
    const url = `${this.apiUrl}/${id}`;

    return this.http.delete<Pet>(url, this.httpOptions).pipe(
      catchError(this.handleError<Pet>('deletePet'))
    );
  }

  /** PUT: update the pet on the server */
  updatePet (pet: Pet,id: number ): Observable<Pet> {
    const url = `${this.apiUrl}/${id}`;

    return this.http.put<Pet>(url, pet, this.httpOptions).pipe(
      catchError(this.handleError<any>('updatePet'))
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
