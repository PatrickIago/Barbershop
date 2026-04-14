import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ServicoDto {
  id: number;
  nome: string;
  preco: number;
  duracao: string; 
}
@Injectable({
  providedIn: 'root'
})
export class ServicoService {

  private readonly API = 'https://localhost:7038/api/Servico';

  constructor(private http: HttpClient) { }

  // Retorna a lista de todos os serviços
  listar(): Observable<ServicoDto[]> {
    return this.http.get<ServicoDto[]>(this.API);
  }

  // Busca um serviço por ID
  buscarPorId(id: number): Observable<ServicoDto> {
    return this.http.get<ServicoDto>(`${this.API}/${id}`);
  }

  // Cria um novo serviço (Enviando o DTO)
  criar(servico: Partial<ServicoDto>): Observable<ServicoDto> {
    return this.http.post<ServicoDto>(this.API, servico);
  }

  // Atualiza um serviço existente
  atualizar(id: number, servico: Partial<ServicoDto>): Observable<any> {
    return this.http.put(`${this.API}/${id}`, servico);
  }

  // Exclui um serviço
  excluir(id: number): Observable<any> {
    return this.http.delete(`${this.API}/${id}`);
  }
}