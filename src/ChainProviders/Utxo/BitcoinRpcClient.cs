using RlBot.ChainProviders.Evm;
using RlBot.ChainProviders.Transport;
using RlBot.Engine.Domain.Models;

namespace RlBot.ChainProviders.Utxo;

public sealed class BitcoinRpcClient : RpcClientBase
{
    public BitcoinRpcClient(HttpTransportLayer transport) : base(transport)
    {
    }

    public override string NetworkId => "bitcoin-mainnet";

    public override async Task<long> GetLatestBlockNumberAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();
        return 850_000;
    }

    public override async Task<decimal> GetNativeBalanceAsync(string address, CancellationToken cancellationToken)
    {
        await Task.Yield();
        return Math.Abs(address.GetHashCode(StringComparison.Ordinal) % 500) / 1000m;
    }

    public override async Task<IReadOnlyList<TransactionRecord>> GetTransactionsAsync(
        string address,
        long fromBlock,
        long toBlock,
        CancellationToken cancellationToken)
    {
        await Task.Yield();
        return EthereumRpcClient.SimulateTransactionHistory(address, fromBlock, toBlock, "BTC");
    }
}
