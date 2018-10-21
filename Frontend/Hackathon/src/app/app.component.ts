import { Component, OnInit } from '@angular/core';

//#region Services
import { ApiHackathonService } from './services/api-hackthon.service';
//#endregion

//#region Interfaces
import { EstadoInterface } from './services/Interfaces/api-hackthon/estado.interface';
import { MunicipioInterface } from './services/Interfaces/api-hackthon/municipio.interface';
import { RankingEscolaInterface } from './services/Interfaces/api-hackthon/ranking-escola.interface';
import { TipoEnsinoInterface } from './services/Interfaces/api-hackthon/tipo-ensino-interface';
//#endregion

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Hackathon';
  public tiposEnsino: Array<TipoEnsinoInterface>;
  public estados: Array<EstadoInterface>;
  public municipios: Array<MunicipioInterface>;
  public rankingEscolas: Array<RankingEscolaInterface>;
  public ano: number = 2017;
  public codigoTipoEnsino: number = 1;
  public uf: string = 'SP';
  public codigoMunicipio: number = null;
  public inclusao: boolean = null;

  constructor(private apiHackathonService: ApiHackathonService){}

  ngOnInit(): void {
    this.getTiposEnsino();
    this.getEstados();
    this.getMunicipioPorUf(this.uf);
  }

  changeTipoEnsino(event: any): void{
    this.codigoTipoEnsino = parseInt((<HTMLInputElement>event.target).value);
  }

  changeUf(event: any): void{
    this.uf = (<HTMLInputElement>event.target).value;
    this.codigoMunicipio = null;
    this.getMunicipioPorUf(this.uf);
  }

  changeMunicipio(event: any): void{
    this.codigoMunicipio = parseInt((<HTMLInputElement>event.target).value);
  }

  checkInclusao(event: any): void{
    if(!event.target.checked){
      this.inclusao = null;
    }else{
      this.inclusao = true;
    }
  }

  gerar(): void{
    if(this.uf != ''){
      if(this.codigoMunicipio != null && this.inclusao != null){
        this.getRankingEscolasPorAnoUfMunicipioInclusao(this.ano, this.codigoTipoEnsino, this.uf, this.codigoMunicipio, this.inclusao);
      }else if(this.codigoMunicipio != null && this.inclusao == null){
        this.getRankingEscolasPorAnoUfMunicipio(this.ano, this.codigoTipoEnsino, this.uf, this.codigoMunicipio);
      }else if(this.codigoMunicipio == null && this.inclusao != null){
        this.getRankingEscolasPorAnoUfInclusao(this.ano, this.codigoTipoEnsino, this.uf, this.inclusao);
      }else{
        this.getRankingEscolasPorAnoUf(this.ano, this.codigoTipoEnsino, this.uf);
      }
    }else{
      alert('Selecione o estado.');
    }
  }

  getTiposEnsino(): void{
    this.apiHackathonService.getTiposEnsino()
    .subscribe((result) => {
      this.tiposEnsino = result;
    });
  }

  getEstados(): void{
    this.apiHackathonService.getEstados()
    .subscribe((result) => {
      this.estados = result;
    });
  }

  getMunicipioPorUf(uf: string): void{
    this.apiHackathonService.getMunicipioPorUf(uf)
    .subscribe((result) => {
      this.municipios = result;
    });
  }

  getRankingEscolasPorAnoUf(ano: number, codigoTipoEnsino: number, uf: string): void{
    this.apiHackathonService.getRankingEscolasPorAnoUf(ano, codigoTipoEnsino, uf)
    .subscribe((result) => {
      this.rankingEscolas = result;
    });
  }
  
  getRankingEscolasPorAnoUfMunicipio(ano: number, codigoTipoEnsino: number, uf: string, codigoMunicipio: number): void{
    this.apiHackathonService.getRankingEscolasPorAnoUfMunicipio(ano, codigoTipoEnsino, uf, codigoMunicipio)
    .subscribe((result) => {
      this.rankingEscolas = result;
    });
  }

  getRankingEscolasPorAnoUfInclusao(ano: number, codigoTipoEnsino: number, uf: string, inclusao: boolean): void{
    this.apiHackathonService.getRankingEscolasPorAnoUfInclusao(ano, codigoTipoEnsino, uf, inclusao)
    .subscribe((result) => {
      this.rankingEscolas = result;
    });
  }

  getRankingEscolasPorAnoUfMunicipioInclusao(ano: number, codigoTipoEnsino: number, uf: string, codigoMunicipio: number, inclusao: boolean): void{
    this.apiHackathonService.getRankingEscolasPorAnoUfMunicipioInclusao(ano, codigoTipoEnsino, uf, codigoMunicipio, inclusao)
    .subscribe((result) => {
      this.rankingEscolas = result;
    });
  }
}
