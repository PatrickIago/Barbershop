import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; // Importação necessária

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  private readonly API = 'https://localhost:7038/api/Agendamento';

  public proximosAgendamentos: any[] = [];
  public totalCortesHoje: number = 0;
  public barbeirosAtivos: number = 0;
  public hoje: Date = new Date();

  // Injetando o Router para a navegação dos cards funcionar
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.obterDadosDaApi();
  }

  irPara(rota: string) {
    this.router.navigate([rota]);
  }

  obterDadosDaApi(): void {
    this.http.get<any[]>(this.API).subscribe({
      next: (dados) => {
        this.proximosAgendamentos = dados;
        this.totalCortesHoje = dados.length;
        this.barbeirosAtivos = new Set(dados.map(a => a.profissionalId)).size;
      },
      error: (err) => console.error('Erro na API:', err)
    });
  }
}