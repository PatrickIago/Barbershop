import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProfissionalService, ProfissionalDto } from '../../services/profissional.service';

@Component({
  selector: 'app-profissional',
  templateUrl: './profissional.component.html',
  styleUrls: ['./profissional.component.css']
})
export class ProfissionalComponent implements OnInit {
  public profissionais: ProfissionalDto[] = [];
  public profissionalForm: FormGroup;
  public exibirModal = false;
  public modoEdicao = false;
  public idSelecionado: number | null = null;

  constructor(
    private profissionalService: ProfissionalService,
    private fb: FormBuilder
  ) {
    this.profissionalForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      celular: ['', Validators.required],
      cpf: ['', Validators.required],
      ativo: [true]
    });
  }

  ngOnInit(): void {
    this.carregarProfissionais();
  }

  carregarProfissionais(): void {
    this.profissionalService.listar().subscribe({
      next: (dados) => this.profissionais = dados,
      error: (err) => console.error(err)
    });
  }

  abrirModal(): void {
    this.modoEdicao = false;
    this.idSelecionado = null;
    this.profissionalForm.reset({ ativo: true });
    this.exibirModal = true;
  }

  editar(p: ProfissionalDto): void {
    this.modoEdicao = true;
    this.idSelecionado = p.id;
    this.profissionalForm.patchValue(p);
    this.exibirModal = true;
  }

  fecharModal(): void {
    this.exibirModal = false;
  }

  salvar(): void {
    if (this.profissionalForm.invalid) return;

    const dados = this.profissionalForm.value;

    if (this.modoEdicao && this.idSelecionado) {
      this.profissionalService.atualizar(this.idSelecionado, { id: this.idSelecionado, ...dados }).subscribe({
        next: () => { this.carregarProfissionais(); this.fecharModal(); }
      });
    } else {
      this.profissionalService.criar(dados).subscribe({
        next: () => { this.carregarProfissionais(); this.fecharModal(); }
      });
    }
  }

  excluir(id: number): void {
    if (confirm('Deseja remover este profissional?')) {
      this.profissionalService.excluir(id).subscribe(() => this.carregarProfissionais());
    }
  }
}