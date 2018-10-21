import {Injectable} from "@angular/core";
 import {Http, Response} from "@angular/http";
 import {Observable} from "rxjs";
 import "rxjs/Rx";
import { EstadoInterface } from "./interfaces/estado.interface";

@Injectable({
  providedIn: 'root'
})
export class ApiHackathonService {
  private apiUrl: string = 'https://localhost:5001/';

  constructor(private http: Http) { }

  getEstados(): Observable<Array<EstadoInterface>> {
    return this.http.get(this.apiUrl + '/v1/estados')
    .map((response: Response) => {
        return <EstadoInterface[]>response.json();
    })
    .catch(this.handleError);
  }

  private handleError(error: Response) {
    console.log(error.statusText);
  }
}
