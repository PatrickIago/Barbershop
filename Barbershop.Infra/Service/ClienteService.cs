using AutoMapper;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;
using Barbershop.Infra.SQL;
using Dapper;
using System.Data;

namespace Barbershop.Infra.Service;
public class ClienteService : IClienteService
{
    private readonly DapperContext _context;
    private readonly IMapper _mapper;

    public ClienteService(DapperContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ClienteViewModel> Create(Cliente cliente)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("NOME", cliente.Nome, DbType.String);
        parameters.Add("EMAIL", cliente.Email, DbType.String);
        parameters.Add("CELULAR", cliente.Celular, DbType.String);
        parameters.Add("CPF", cliente.CPF, DbType.String);
        parameters.Add("DATACADASTRO", cliente.DataCadastro, DbType.DateTime);

        var novoId = await dbConnection.QuerySingleAsync<int>(
            ClienteSqlConsts.SQL_INSERT,
            parameters
        );

        cliente.SetClienteId(novoId);
        return _mapper.Map<ClienteViewModel>(cliente);
    }

    public async Task<bool> Delete(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);

        var affectedRows = await dbConnection.ExecuteAsync(
            ClienteSqlConsts.SQL_DELETE,
            parameters
        );

        return affectedRows > 0;
    }

    public async Task<List<ClienteViewModel>> Get()
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryAsync<Cliente>(ClienteSqlConsts.SQL_GET);
        var mapper = _mapper.Map<List<ClienteViewModel>>(result);
        return mapper.ToList();
    }

    public async Task<ClienteViewModel> Get(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryFirstOrDefaultAsync<Cliente>(
            ClienteSqlConsts.SQL_GET_BY_ID, new { Id = id });

        if (result == null)
        {
            return null;
        }

        var mapper = _mapper.Map<ClienteViewModel>(result);
        return mapper;
    }

    public async Task<bool> Update(Cliente cliente)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", cliente.Id, DbType.Int32);
        parameters.Add("Nome", cliente.Nome, DbType.String);
        parameters.Add("Email", cliente.Email, DbType.String);
        parameters.Add("Celular", cliente.Celular, DbType.String);
        parameters.Add("CPF", cliente.CPF, DbType.String);

        var affectedRows = await dbConnection.ExecuteAsync(
            ClienteSqlConsts.SQL_UPDATE,
            parameters
        );

        return affectedRows > 0;
    }
}
