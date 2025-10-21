using AutoMapper;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using Barbershop.Infra.SQL;
using Dapper;
using System.Data;

namespace Barbershop.Infra.Service;
public class ServicoService : IServicoService
{
    private readonly DapperContext _context;
    private readonly IMapper _mapper;

    public ServicoService(DapperContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServicoViewModel> Create(Servico servico)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Nome", servico.Nome, DbType.String);
        parameters.Add("Preco", servico.Preco, DbType.Decimal);
        parameters.Add("Duracao", servico.Duracao, DbType.Time);

        var novoId = await dbConnection.QuerySingleAsync<int>(
            ServicoSqlConsts.SQL_INSERT,
            parameters
        );

        servico.SetServicoId(novoId);
        return _mapper.Map<ServicoViewModel>(servico);
    }

    public async Task<bool> Delete(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);

        var affectedRows = await dbConnection.ExecuteAsync(
            ServicoSqlConsts.SQL_DELETE,
            parameters
        );

        return affectedRows > 0;
    }

    public async Task<List<ServicoViewModel>> Get()
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryAsync<Servico>(ServicoSqlConsts.SQL_GET);
        var mapper = _mapper.Map<List<ServicoViewModel>>(result);
        return mapper.ToList();
    }

    public async Task<ServicoViewModel> Get(int id)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var result = await dbConnection.QueryFirstOrDefaultAsync<Servico>(
            ServicoSqlConsts.SQL_GET_BY_ID, new { Id = id });

        if (result == null)
        {
            return null;
        }

        var mapper = _mapper.Map<ServicoViewModel>(result);
        return mapper;
    }

    public async Task<bool> Update(Servico servico)
    {
        using IDbConnection dbConnection = _context.CreateConnection();
        dbConnection.Open();

        var parameters = new DynamicParameters();
        parameters.Add("Id", servico.Id, DbType.Int32);
        parameters.Add("Nome", servico.Nome, DbType.String);
        parameters.Add("Preco", servico.Preco, DbType.Decimal);
        parameters.Add("Duracao", servico.Duracao, DbType.Time);

        var affectedRows = await dbConnection.ExecuteAsync(
            ServicoSqlConsts.SQL_UPDATE,
            parameters
        );

        return affectedRows > 0;
    }
}
