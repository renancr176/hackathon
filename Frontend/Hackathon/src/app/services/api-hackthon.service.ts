import {Injectable} from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

//#region Interfaces
import { EstadoInterface } from "./interfaces/api-hackthon/estado.interface";
import { MunicipioInterface } from "./Interfaces/api-hackthon/municipio.interface";
import { RankingEscolaInterface } from "./Interfaces/api-hackthon/ranking-escola.interface";
import { TipoEnsinoInterface } from "./Interfaces/api-hackthon/tipo-ensino-interface";
//#endregion

@Injectable({
  providedIn: 'root'
})
export class ApiHackathonService {
  private apiUrl: string = 'http://localhost:5000/';

  constructor(private http: HttpClient) { }

  getTiposEnsino(): Observable<Array<TipoEnsinoInterface>> {
    return this.http.get<Array<TipoEnsinoInterface>>(this.apiUrl + 'v1/tipo_ensino');
  }

  getEstados(): Observable<Array<EstadoInterface>> {
    return this.http.get<Array<EstadoInterface>>(this.apiUrl + 'v1/estado');
  }

  getMunicipioPorUf(uf: string): Observable<Array<MunicipioInterface>> {
    return this.http.get<Array<MunicipioInterface>>(this.apiUrl + 'v1/municipio/' + uf);
  }

  getRankingEscolasPorAnoUf(ano: number, codigoTipoEnsino: number, uf: string): Observable<Array<RankingEscolaInterface>> {
    return this.http.get<Array<RankingEscolaInterface>>(this.apiUrl + 'v1/ranking_escolas/'+ano.toString()+'/'+codigoTipoEnsino.toString()+'/'+uf);
  }

  getRankingEscolasPorAnoUfMunicipio(ano: number, codigoTipoEnsino: number, uf: string, codigoMunicipio: number): Observable<Array<RankingEscolaInterface>> {
    return this.http.get<Array<RankingEscolaInterface>>(this.apiUrl + 'v1/ranking_escolas/'+ano.toString()+'/'+codigoTipoEnsino.toString()+'/'+uf+'/'+codigoMunicipio.toString());
  }

  getRankingEscolasPorAnoUfInclusao(ano: number, codigoTipoEnsino: number, uf: string, inclusao: boolean): Observable<Array<RankingEscolaInterface>> {
    return this.http.get<Array<RankingEscolaInterface>>(this.apiUrl + 'v1/ranking_escolas/'+ano.toString()+'/'+codigoTipoEnsino.toString()+'/'+uf+'/'+inclusao);
  }

  getRankingEscolasPorAnoUfMunicipioInclusao(ano: number, codigoTipoEnsino: number, uf: string, codigoMunicipio: number, inclusao: boolean): Observable<Array<RankingEscolaInterface>> {
    return this.http.get<Array<RankingEscolaInterface>>(this.apiUrl + 'v1/ranking_escolas/'+ano.toString()+'/'+codigoTipoEnsino.toString()+'/'+uf+'/'+codigoMunicipio.toString()+'/'+inclusao);
  }
}