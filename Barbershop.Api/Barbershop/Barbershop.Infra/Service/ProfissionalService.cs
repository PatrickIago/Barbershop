using AutoMapper;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;
using Barbershop.Infra.SQL;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace Barbershop.Infra.Service;
public class ProfissionalService : IProfissionalService
{
    private readonly DapperContext _context;
    private readonly IMapper _mapper;

    public ProfissionalService(DapperContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProfissionalViewModel> Create(Profissional profissional)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();


        var parameters = new DynamicParameters();
        parameters.Add("NOME", profissional.Nome, DbType.String);
        parameters.Add("CELULAR", profissional.Celular, DbType.String);
        parameters.Add("CPF", profissional.CPF, DbType.String);
        parameters.Add("ATIVO", profissional.Ativo, DbType.Boolean);

        var novoId = await dbConnection.QuerySingleAsync<int>(
            ProfissionalSqlConsts.SQL_INSERT,
            parameters
        );

        profissional.SetProfissionalId(novoId);
        return _mapper.Map<ProfissionalViewModel>(profissional);
    }

    public async Task<bool> Delete(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);

        var affectedRows = await dbConnection.ExecuteAsync(
            ProfissionalSqlConsts.SQL_DELETE,
            parameters
        );

        return affectedRows > 0;
    }

    public async Task<List<ProfissionalViewModel>> Get()
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryAsync<Profissional>(ProfissionalSqlConsts.SQL_GET);
        var mapper = _mapper.Map<List<ProfissionalViewModel>>(result);
        return mapper.ToList();
    }

    public async Task<ProfissionalViewModel> Get(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryFirstOrDefaultAsync<Profissional>(
             ProfissionalSqlConsts.SQL_GET_BY_ID, new { Id = id });

        if (result == null)
        {
            return null;
        }

        var mapper = _mapper.Map<ProfissionalViewModel>(result);

        return mapper;

    }

    public async Task<bool> Update(Profissional profissional)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", profissional.Id, DbType.Int32);
        parameters.Add("Nome", profissional.Nome, DbType.String);
        parameters.Add("Celular", profissional.Celular, DbType.String);
        parameters.Add("CPF", profissional.CPF, DbType.String);
        parameters.Add("Ativo", profissional.Ativo, DbType.Boolean);

        var affectedRows = await dbConnection.ExecuteAsync(
            ProfissionalSqlConsts.SQL_UPDATE,
            parameters
        );

        return affectedRows > 0;
    }
}

