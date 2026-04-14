import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServicoService, ServicoDto } from '../../services/servico.service';

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html',
  styleUrls: ['./servico.component.css']
})
export class ServicoComponent implements OnInit {
  
  // Lista de serviços vinda da API
  public servicos: ServicoDto[] = [];
  
  // Controle do Formulário Reativo
  public servicoForm: FormGroup;
  
  // Controle de Estado da UI
  public exibirModal = false;
  public modoEdicao = false;
  public idSelecionado: number | null = null;

  constructor(
    private servicoService: ServicoService,
    private fb: FormBuilder
  ) {
    // Inicialização do formulário com validações rigorosas
    this.servicoForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(3)]],
      preco: [0, [Validators.required, Validators.min(0.01)]],
      duracao: ['01:00:00', [Validators.required, Validators.pattern(/^(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d$/)]]
    });
  }

  ngOnInit(): void {
    this.listarServicos();
  }

  listarServicos(): void {
    this.servicoService.listar().subscribe({
      next: (dados) => {
        this.servicos = dados;
        console.log('Serviços carregados:', dados);
      },
      error: (err) => console.error('Erro ao buscar serviços:', err)
    });
  }

  // Prepara o modal para um novo cadastro
  abrirModal(): void {
    this.modoEdicao = false;
    this.idSelecionado = null;
    this.servicoForm.reset({ preco: 0, duracao: '01:00:00' });
    this.exibirModal = true;
  }

  // Prepara o modal para edição de um serviço existente
  editar(servico: ServicoDto): void {
    this.modoEdicao = true;
    this.idSelecionado = servico.id;
    this.exibirModal = true;
    
    // Preenche o formulário com os dados atuais
    this.servicoForm.patchValue({
      nome: servico.nome,
      preco: servico.preco,
      duracao: servico.duracao
    });
  }

  fecharModal(): void {
    this.exibirModal = false;
    this.idSelecionado = null;
  }

  salvar(): void {
    if (this.servicoForm.invalid) return;

    const dadosDoForm = this.servicoForm.value;

    if (this.modoEdicao && this.idSelecionado) {
      // Montagem do objeto Command para o PUT (Resolvendo o erro 400)
      const updateCommand = {
        id: this.idSelecionado, // O ID deve ser igual ao da rota
        nome: dadosDoForm.nome,
        preco: dadosDoForm.preco,
        duracao: dadosDoForm.duracao
      };

      this.servicoService.atualizar(this.idSelecionado, updateCommand).subscribe({
        next: () => {
          this.listarServicos();
          this.fecharModal();
          console.log('Serviço atualizado com sucesso!');
        },
        error: (err) => {
          console.error('Erro no PUT:', err);
          // O erro 400 do .NET geralmente detalha qual campo falhou em err.error.errors
        }
      });

    } else {
      // Lógica para o POST (Create)
      this.servicoService.criar(dadosDoForm).subscribe({
        next: () => {
          this.listarServicos();
          this.fecharModal();
          console.log('Serviço criado com sucesso!');
        },
        error: (err) => console.error('Erro no POST:', err)
      });
    }
  }

  deletarServico(id: number): void {
    if (confirm('Deseja realmente remover este serviço?')) {
      this.servicoService.excluir(id).subscribe({
        next: () => {
          this.listarServicos();
          console.log('Serviço removido');
        },
        error: (err) => console.error('Erro ao deletar:', err)
      });
    }
  }
}