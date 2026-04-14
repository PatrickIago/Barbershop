import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService, ClienteDto } from '../../services/cliente.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  public clientes: ClienteDto[] = [];
  public clienteForm: FormGroup;
  public exibirModal = false;
  public modoEdicao = false;
  public idSelecionado: number | null = null;
  public mostrarInativos = false;

  constructor(
    private clienteService: ClienteService,
    private fb: FormBuilder
  ) {
    this.clienteForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]],
      celular: ['', Validators.required],
      cpf: ['', Validators.required],
      ativo: [true]
    });
  }

  ngOnInit(): void {
    this.carregarClientes();
  }

  get clientesFiltrados() {
    return this.clientes.filter(c => c.ativo === !this.mostrarInativos);
  }

  toggleFiltro() {
    this.mostrarInativos = !this.mostrarInativos;
  }

  carregarClientes(): void {
    this.clienteService.listar().subscribe({
      next: (dados) => this.clientes = dados,
      error: (err) => console.error(err)
    });
  }

  abrirModal(): void {
    this.modoEdicao = false;
    this.idSelecionado = null;
    this.clienteForm.reset({ ativo: true });
    this.exibirModal = true;
  }

  fecharModal(): void {
    this.exibirModal = false;
  }

  editar(cliente: ClienteDto): void {
    this.modoEdicao = true;
    this.idSelecionado = cliente.id;
    this.clienteForm.patchValue(cliente);
    this.exibirModal = true;
  }

  salvar(): void {
    if (this.clienteForm.invalid) return;
    const formValues = this.clienteForm.value;
    const cpfLimpo = formValues.cpf.replace(/\D/g, '');

    if (this.modoEdicao && this.idSelecionado) {
      const updateCommand = { ...formValues, id: this.idSelecionado, cpf: cpfLimpo };
      this.clienteService.atualizar(this.idSelecionado, updateCommand).subscribe({
        next: () => { this.carregarClientes(); this.fecharModal(); }
      });
    } else {
      const createCommand = { 
        ...formValues, 
        cpf: cpfLimpo, 
        ativo: true, 
        dataCadastro: new Date() 
      };
      this.clienteService.criar(createCommand).subscribe({
        next: () => { this.carregarClientes(); this.fecharModal(); },
        error: (err) => console.error(err.error)
      });
    }
  }

  excluir(id: number): void {
    if (confirm('Deseja realmente desativar este cliente?')) {
      this.clienteService.excluir(id).subscribe({
        next: () => this.carregarClientes()
      });
    }
  }

  reativar(cliente: ClienteDto): void {
    if (confirm(`Deseja reativar o cliente ${cliente.nome}?`)) {
      const updateData = { ...cliente, ativo: true };
      this.clienteService.atualizar(cliente.id, updateData).subscribe({
        next: () => this.carregarClientes()
      });
    }
  }
}