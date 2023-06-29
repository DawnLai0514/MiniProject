﻿using dotNet.ServiceModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.Interface
{
    public interface ITradeService
    {
        public Task<string> InsertTwseDataToDB(string startDate, DateTime endDate);

        public Task<Tuple<List<TradeRespServiceModel>,int>> GetStockListFromDB(int pageIndex, int pageSize, string sortColumn, DateTime startDate, DateTime endDate, string tradeType, string stockId, string sortDirection);

        public Task<string> DeleteStockByStatus(int id);

        public Task<TradeRespServiceModel> GetStockById(int id);

        public Task<string> UpdateStockById(TradeServiceModel stock);
    }
}
