import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 

// Importação do Toastr
import { ToastrModule } from 'ngx-toastr';

// Roteamento
import { AppRoutingModule } from './app-routing.module';

// Componentes
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ServicoComponent } from './components/servico/servico.component';
import { ProfissionalComponent } from './components/profissional/profissional.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { AgendamentoComponent } from './components/agendamento/agendamento.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ServicoComponent,
    ProfissionalComponent,
    ClienteComponent,
    AgendamentoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      progressAnimation: 'decreasing',
      closeButton: true
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }