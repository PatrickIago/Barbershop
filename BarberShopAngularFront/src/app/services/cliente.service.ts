import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ClienteDto {
  id: number;
  nome: string;
  email: string;
  celular: string;
  cpf: string;
  dataCadastro: Date; 
  ativo: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private readonly API = 'https://localhost:7038/api/Cliente';

  constructor(private http: HttpClient) { }

  listar(): Observable<ClienteDto[]> {
    return this.http.get<ClienteDto[]>(this.API);
  }

  criar(cliente: Partial<ClienteDto>): Observable<ClienteDto> {
    return this.http.post<ClienteDto>(this.API, cliente);
  }

  atualizar(id: number, cliente: Partial<ClienteDto>): Observable<any> {
    return this.http.put(`${this.API}/${id}`, cliente);
  }

  excluir(id: number): Observable<any> {
    return this.http.delete(`${this.API}/${id}`);
  }
}