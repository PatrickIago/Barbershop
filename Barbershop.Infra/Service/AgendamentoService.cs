using AutoMapper;
using Barbershop.Application.DTO;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;
using Barbershop.Infra.SQL;
using Dapper;
using System.Data;

namespace Barbershop.Infra.Service;

public class AgendamentoService : IAgendamentoService
{
    private readonly DapperContext _context;
    private readonly IMapper _mapper;

    public AgendamentoService(DapperContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<AgendamentoViewModel>> Get()
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryAsync<AgendamentoDto>(AgendamentoSqlConsts.SQL_GET);
        return result.Select(dto => _mapper.Map<AgendamentoViewModel>(dto.MapToResult())).ToList();
    }

    public async Task<AgendamentoViewModel> Get(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryFirstOrDefaultAsync<AgendamentoDto>(
            AgendamentoSqlConsts.SQL_GET_BY_ID, new { Id = id });

        if (result == null)
            return null;

        return _mapper.Map<AgendamentoViewModel>(result.MapToResult());
    }

    public async Task<List<AgendamentoViewModel>> GetByDia(DateTime dia)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryAsync<AgendamentoDto>(
            AgendamentoSqlConsts.SQL_GET_BY_DIA, new { Dia = dia.Date });

        return result.Select(dto => _mapper.Map<AgendamentoViewModel>(dto.MapToResult())).ToList();
    }

    public async Task Create(Agendamento agendamento)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("DataHora", agendamento.DataHora, DbType.DateTime);
        parameters.Add("ServicoId", agendamento.ServicoId, DbType.Int32);
        parameters.Add("ProfissionalId", agendamento.ProfissionalId, DbType.Int32);
        parameters.Add("ClienteId", agendamento.ClienteId, DbType.Int32);

        var novoId = await dbConnection.QuerySingleAsync<int>(
            AgendamentoSqlConsts.SQL_INSERT, parameters);

        agendamento.SetAgendamentoId(novoId);
    }

    public async Task<bool> Update(Agendamento agendamento)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", agendamento.Id, DbType.Int32);
        parameters.Add("DataHora", agendamento.DataHora, DbType.DateTime);
        parameters.Add("ServicoId", agendamento.ServicoId, DbType.Int32);
        parameters.Add("ProfissionalId", agendamento.ProfissionalId, DbType.Int32);
        parameters.Add("ClienteId", agendamento.ClienteId, DbType.Int32);

        var affectedRows = await dbConnection.ExecuteAsync(
            AgendamentoSqlConsts.SQL_UPDATE, parameters);

        return affectedRows > 0;
    }

    public async Task<bool> Delete(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var affectedRows = await dbConnection.ExecuteAsync(
            AgendamentoSqlConsts.SQL_DELETE, new { Id = id });

        return affectedRows > 0;
    }
}
