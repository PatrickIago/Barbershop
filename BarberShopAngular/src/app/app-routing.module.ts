import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ServicoComponent } from './components/servico/servico.component';
import { ProfissionalComponent } from './components/profissional/profissional.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { AgendamentoComponent } from './components/agendamento/agendamento.component';

const routes: Routes = [

  // Padrão 
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  // Dashboard
  { path: 'dashboard', component: DashboardComponent },
 // Serviço  
  { path: 'servicos', component: ServicoComponent },
  // Profissional
  { path: 'profissionais', component: ProfissionalComponent },
  // Cliente
  { path: 'clientes', component: ClienteComponent },
  // Agendamento
  { path: 'agendamentos', component: AgendamentoComponent }

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
