using Barbershop.Application.DTO;

namespace Barbershop.Infra.SQL;
public static class ClienteSqlConsts
{
    public const string SQL_GET =
    @$"
        SELECT 
            ID AS {nameof(ClienteDto.Id)},
            NOME AS {nameof(ClienteDto.Nome)},
            EMAIL AS {nameof(ClienteDto.Email)},
            CELULAR AS {nameof(ClienteDto.Celular)},
            CPF AS {nameof(ClienteDto.CPF)},
            DATACADASTRO AS {nameof(ClienteDto.DataCadastro)}
        FROM CLIENTES
    ";

    public const string SQL_MAX =
    @$"
        SELECT COALESCE(MAX(ID), 0) + 1 
        FROM CLIENTES
    ";

    public const string SQL_GET_BY_ID =
    @$"
        SELECT 
            ID AS {nameof(ClienteDto.Id)},
            NOME AS {nameof(ClienteDto.Nome)},
            EMAIL AS {nameof(ClienteDto.Email)},
            CELULAR AS {nameof(ClienteDto.Celular)},
            CPF AS {nameof(ClienteDto.CPF)},
            DATACADASTRO AS {nameof(ClienteDto.DataCadastro)}
        FROM CLIENTES
        WHERE ID = @Id
    ";

    public const string SQL_INSERT =
    @$"
        INSERT INTO CLIENTES (NOME, EMAIL, CELULAR, CPF, DATACADASTRO)
        VALUES (@Nome, @Email, @Celular, @CPF, @DataCadastro);
        SELECT SCOPE_IDENTITY();
    ";

    public const string SQL_UPDATE =
    @$"
        UPDATE CLIENTES
        SET 
            NOME = @Nome,
            EMAIL = @Email,
            CELULAR = @Celular,
            CPF = @CPF
        WHERE ID = @Id
    ";

    public const string SQL_DELETE =
    @$"
        DELETE FROM CLIENTES
        WHERE ID = @Id
    ";
}
