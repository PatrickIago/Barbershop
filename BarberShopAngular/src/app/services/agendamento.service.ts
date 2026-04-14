import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CreateAgendamentoCommand {
  dataHora: string;
  servicoId: number;
  profissionalId: number;
  clienteId: number;
}

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {
  // Seguindo o seu padrão de nome e URL
  private readonly API = 'https://localhost:7038/api/Agendamento';

  constructor(private http: HttpClient) { }

  // Seguindo o seu padrão de métodos (listar, criar, etc)
  listar(): Observable<any[]> {
    return this.http.get<any[]>(this.API);
  }

  // O criar aqui é o que dispara o comando que envia o e-mail no seu Back
  criar(command: CreateAgendamentoCommand): Observable<any> {
    return this.http.post<any>(this.API, command);
  }

  excluir(id: number): Observable<any> {
    return this.http.delete(`${this.API}/${id}`);
  }

  // Métodos para buscar os dados dos outros controllers para os seus cards
  listarClientes(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7038/api/Cliente');
  }

  listarServicos(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7038/api/Servico');
  }

  listarProfissionais(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7038/api/Profissional');
  }
}