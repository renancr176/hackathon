import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConsultaRoutingModule } from './consulta-routing.module';
import { ConsultaComponent } from './consulta.component';

@NgModule({
  imports: [
    CommonModule,
    ConsultaRoutingModule
  ],
  declarations: [ConsultaComponent]
})
export class ConsultaModule { }
