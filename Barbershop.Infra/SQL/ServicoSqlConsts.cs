using Barbershop.Application.DTO;

namespace Barbershop.Infra.SQL;
public static class ServicoSqlConsts
{
    public const string SQL_GET =
    @$"
        SELECT 
            ID AS {nameof(ServicoDto.Id)},
            NOME AS {nameof(ServicoDto.Nome)},
            PRECO AS {nameof(ServicoDto.Preco)},
            DURACAO AS {nameof(ServicoDto.Duracao)}
        FROM SERVICOS
    ";

    public const string SQL_MAX =
    @$"
        SELECT COALESCE(MAX(ID), 0) + 1 
        FROM SERVICOS
    ";

    public const string SQL_GET_BY_ID =
    @$"
        SELECT 
            ID AS {nameof(ServicoDto.Id)},
            NOME AS {nameof(ServicoDto.Nome)},
            PRECO AS {nameof(ServicoDto.Preco)},
            DURACAO AS {nameof(ServicoDto.Duracao)}
        FROM SERVICOS
        WHERE ID = @Id
    ";

    public const string SQL_INSERT =
    @$"
        INSERT INTO SERVICOS (NOME, PRECO, DURACAO)
        VALUES (@Nome, @Preco, @Duracao);
        SELECT SCOPE_IDENTITY();
    ";

    public const string SQL_UPDATE =
    @$"
        UPDATE SERVICOS
        SET 
            NOME = @Nome,
            PRECO = @Preco,
            DURACAO = @Duracao
        WHERE ID = @Id
    ";

    public const string SQL_DELETE =
    @$"
        DELETE FROM SERVICOS
        WHERE ID = @Id
    ";
}
