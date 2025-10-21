using Barbershop.Application.DTO;

namespace Barbershop.Infra.SQL;
public static class ProfissionalSqlConsts
{
    public const string SQL_GET =
    @$"
        SELECT 
            ID AS {nameof(ProfissionalDto.Id)},
            NOME AS {nameof(ProfissionalDto.Nome)},
            CELULAR AS {nameof(ProfissionalDto.Celular)},
            CPF AS {nameof(ProfissionalDto.CPF)},
            ATIVO AS {nameof(ProfissionalDto.Ativo)}
        FROM PROFISSIONAIS
    ";

    public const string SQL_MAX =
    @$"
    SELECT COALESCE(MAX(ID), 0) + 1 
    FROM PROFISSIONAIS
    ";

    public const string SQL_GET_BY_ID =
    @$"
        SELECT 
            ID AS {nameof(ProfissionalDto.Id)},
            NOME AS {nameof(ProfissionalDto.Nome)},
            CELULAR AS {nameof(ProfissionalDto.Celular)},
            CPF AS {nameof(ProfissionalDto.CPF)},
            ATIVO AS {nameof(ProfissionalDto.Ativo)}
        FROM PROFISSIONAIS
        WHERE ID = @Id
    ";

    public const string SQL_INSERT =
    @$"
         INSERT INTO PROFISSIONAIS (NOME, CELULAR, CPF, ATIVO)
         VALUES (@Nome, @Celular, @CPF, @Ativo);
         SELECT SCOPE_IDENTITY();
    ";

    public const string SQL_UPDATE =
    @$"
        UPDATE PROFISSIONAIS
        SET 
            NOME = @Nome,
            CELULAR = @Celular,
            CPF = @CPF,
            ATIVO = @Ativo
        WHERE ID = @Id
    ";

    public const string SQL_DELETE =
    @$"
        DELETE FROM PROFISSIONAIS
        WHERE ID = @Id
    ";
}
