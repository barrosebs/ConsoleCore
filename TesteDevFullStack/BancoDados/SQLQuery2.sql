SELECT * FROM TBFinanciamento F
JOIN TBCliente C ON C.idCliente = F.IdCliente
JOIN TBParcela P ON P.idFinanciamento = F.IdFinanciamento
WHERE C.uf = 'SP' and P.dataPagamento is not null