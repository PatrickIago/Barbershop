import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ProfissionalDto {
  id: number;
  nome: string;
  celular: string;
  cpf: string;
  ativo: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ProfissionalService {
  private readonly API = 'https://localhost:7038/api/Profissional';

  constructor(private http: HttpClient) { }

  listar(): Observable<ProfissionalDto[]> {
    return this.http.get<ProfissionalDto[]>(this.API);
  }

  criar(profissional: Partial<ProfissionalDto>): Observable<ProfissionalDto> {
    return this.http.post<ProfissionalDto>(this.API, profissional);
  }

  atualizar(id: number, profissional: Partial<ProfissionalDto>): Observable<any> {
    return this.http.put(`${this.API}/${id}`, profissional);
  }

  excluir(id: number): Observable<any> {
    return this.http.delete(`${this.API}/${id}`);
  }
}