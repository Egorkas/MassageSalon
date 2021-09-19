import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class MasseurService {
private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44379/api/masseurs';

  constructor(private http: HttpClient) {
	this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }
  
  public get():Observable<any[]>{
	  return this.http.get<any>(this.accessPointUrl, {headers: this.headers});
  }
}
