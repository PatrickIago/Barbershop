using Barbershop.Application.DTO;

namespace Barbershop.Infra.SQL;

public static class AgendamentoSqlConsts
{
    public const string SQL_GET =
    @$"
        SELECT 
            A.ID AS {nameof(AgendamentoDto.Id)},
            A.DATAHORA AS {nameof(AgendamentoDto.DataHora)},

            A.SERVICOID AS {nameof(AgendamentoDto.ServicoId)},
            S.NOME AS {nameof(AgendamentoDto.ServicoNome)},

            A.PROFISSIONALID AS {nameof(AgendamentoDto.ProfissionalId)},
            P.NOME AS {nameof(AgendamentoDto.ProfissionalNome)},

            A.CLIENTEID AS {nameof(AgendamentoDto.ClienteId)},
            C.NOME AS {nameof(AgendamentoDto.ClienteNome)},
            C.EMAIL AS {nameof(AgendamentoDto.ClienteEmail)}

        FROM AGENDAMENTOS A
        INNER JOIN SERVICOS S ON S.ID = A.SERVICOID
        INNER JOIN PROFISSIONAIS P ON P.ID = A.PROFISSIONALID
        INNER JOIN CLIENTES C ON C.ID = A.CLIENTEID
    ";

    public const string SQL_GET_BY_ID =
    @$"
        SELECT 
            A.ID AS {nameof(AgendamentoDto.Id)},
            A.DATAHORA AS {nameof(AgendamentoDto.DataHora)},

            A.SERVICOID AS {nameof(AgendamentoDto.ServicoId)},
            S.NOME AS {nameof(AgendamentoDto.ServicoNome)},

            A.PROFISSIONALID AS {nameof(AgendamentoDto.ProfissionalId)},
            P.NOME AS {nameof(AgendamentoDto.ProfissionalNome)},

            A.CLIENTEID AS {nameof(AgendamentoDto.ClienteId)},
            C.NOME AS {nameof(AgendamentoDto.ClienteNome)},
            C.EMAIL AS {nameof(AgendamentoDto.ClienteEmail)}

        FROM AGENDAMENTOS A
        INNER JOIN SERVICOS S ON S.ID = A.SERVICOID
        INNER JOIN PROFISSIONAIS P ON P.ID = A.PROFISSIONALID
        INNER JOIN CLIENTES C ON C.ID = A.CLIENTEID
        WHERE A.ID = @Id
    ";

    public const string SQL_GET_BY_DIA =
    @$"
        SELECT 
            A.ID AS {nameof(AgendamentoDto.Id)},
            A.DATAHORA AS {nameof(AgendamentoDto.DataHora)},

            A.SERVICOID AS {nameof(AgendamentoDto.ServicoId)},
            S.NOME AS {nameof(AgendamentoDto.ServicoNome)},

            A.PROFISSIONALID AS {nameof(AgendamentoDto.ProfissionalId)},
            P.NOME AS {nameof(AgendamentoDto.ProfissionalNome)},

            A.CLIENTEID AS {nameof(AgendamentoDto.ClienteId)},
            C.NOME AS {nameof(AgendamentoDto.ClienteNome)},
            C.EMAIL AS {nameof(AgendamentoDto.ClienteEmail)}

        FROM AGENDAMENTOS A
        INNER JOIN SERVICOS S ON S.ID = A.SERVICOID
        INNER JOIN PROFISSIONAIS P ON P.ID = A.PROFISSIONALID
        INNER JOIN CLIENTES C ON C.ID = A.CLIENTEID
        WHERE CAST(A.DATAHORA AS DATE) = @Dia
    ";

    public const string SQL_INSERT =
    @$"
        INSERT INTO AGENDAMENTOS (DATAHORA, SERVICOID, PROFISSIONALID, CLIENTEID)
        VALUES (@DataHora, @ServicoId, @ProfissionalId, @ClienteId);
        SELECT SCOPE_IDENTITY();
    ";

    public const string SQL_UPDATE =
    @$"
        UPDATE AGENDAMENTOS
        SET 
            DATAHORA = @DataHora,
            SERVICOID = @ServicoId,
            PROFISSIONALID = @ProfissionalId,
            CLIENTEID = @ClienteId
        WHERE ID = @Id
    ";

    public const string SQL_DELETE =
    @$"
        DELETE FROM AGENDAMENTOS
        WHERE ID = @Id
    ";
}
