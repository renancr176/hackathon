import { Component, OnInit } from '@angular/core';
import { ApiHackathonService } from './services/api-hackathon.service';
import { EstadoInterface } from './services/interfaces/estado.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  
  title = 'Hackathon';
  public estados: Array<EstadoInterface>;

  constructor(private apiHackathonService: ApiHackathonService){}

  ngOnInit(): void {
    //this.getEstados();
  }

  /*getEstados(): void{
    this.apiHackathonService.getEstados()
    .subscribe(
      (response) => {
        this.estados = response.body.;
      },
      (error) => {
        console.log(error);
      }
    );
  }*/
}
