import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AgendamentoService, CreateAgendamentoCommand } from 'src/app/services/agendamento.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {
  form!: FormGroup;
  loading: boolean = false;

  clientes: any[] = [];
  clientesFiltrados: any[] = [];
  servicos: any[] = [];
  profissionais: any[] = [];

  termoBuscaCpf: string = '';
  minDate: string = '';

  constructor(
    private fb: FormBuilder,
    private agendamentoService: AgendamentoService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.setMinDate();
    this.initForm();
    this.carregarDados();
  }

  private initForm() {
    this.form = this.fb.group({
      clienteId: [null, Validators.required],
      servicoId: [null, Validators.required],
      profissionalId: [null, Validators.required],
      dataHora: ['', Validators.required]
    });
  }

  private setMinDate() {
    const agora = new Date();
    const ano = agora.getFullYear();
    const mes = String(agora.getMonth() + 1).padStart(2, '0');
    const dia = String(agora.getDate()).padStart(2, '0');
    const hora = String(agora.getHours()).padStart(2, '0');
    const minuto = String(agora.getMinutes()).padStart(2, '0');
    this.minDate = `${ano}-${mes}-${dia}T${hora}:${minuto}`;
  }

  private carregarDados() {
    this.agendamentoService.listarClientes().subscribe(res => {
      this.clientes = res;
      this.clientesFiltrados = res;
    });
    this.agendamentoService.listarServicos().subscribe(res => this.servicos = res);
    this.agendamentoService.listarProfissionais().subscribe(res => this.profissionais = res);
  }

  filtrarClientes() {
    const busca = this.termoBuscaCpf.toLowerCase().trim();
    if (!busca) {
      this.clientesFiltrados = this.clientes;
      return;
    }
    this.clientesFiltrados = this.clientes.filter(c => 
      c.cpf.includes(busca) || 
      c.nome.toLowerCase().includes(busca)
    );
  }

  onSubmit() {
    if (this.form.invalid) return;

    this.loading = true;
    const command: CreateAgendamentoCommand = this.form.value;

    this.agendamentoService.criar(command).subscribe({
      next: () => {
        this.loading = false;
        this.toastr.success('Agendamento realizado com sucesso!', 'BarberShop');
        this.form.reset();
        this.termoBuscaCpf = '';
        this.clientesFiltrados = this.clientes;
        this.setMinDate();
      },
      error: (err) => {
        this.loading = false;
        this.toastr.error(err.error?.message || 'Erro ao realizar agendamento.', 'Ops!');
      }
    });
  }
}