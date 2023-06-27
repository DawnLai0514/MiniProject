﻿using AutoMapper;
using dotNet.Interface;
using dotNet.Models;
using dotNet.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace dotNet.Service
{
    public class StockService : IStockService
    {
        private readonly IHttpClientFactory _clientFactory;
        private MiniProjectDBContext _context;
        private IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly ITradeHelper _tradeHelper;


        public StockService(IHttpClientFactory clientFactory, MiniProjectDBContext context, IMapper mapper, IStockRepository stockRepository, ITradeHelper tradeHelper)
        {
            _context = context;
            _clientFactory = clientFactory;
            _mapper = mapper;
            _stockRepository = stockRepository;
            _tradeHelper = tradeHelper;
        }
        public async Task<StockRespServiceModel> GetStockInfo(string id, DateTime tradeDate)
        {
            DateTime time = tradeDate.AddDays(-1);
            var closingPriceTables = await _context.ClosingPriceTables.FirstOrDefaultAsync(x => x.TradeDate == time && x.StockId == id);
            return _mapper.Map<StockRespServiceModel>(closingPriceTables);
        }
    }
}