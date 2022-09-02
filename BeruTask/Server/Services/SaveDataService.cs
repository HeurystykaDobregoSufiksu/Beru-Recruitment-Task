﻿using BeruTask.Server.DTOs;
using BeruTask.Server.Models;
using BeruTask.Server.Repository.Interfaces;
using BeruTask.Server.Services.Interfaces;
using System.Text.Json;

namespace BeruTask.Server.Services
{
    public class SaveDataService:ISaveDataService
    {
        private readonly IGoldPriceRepo _goldPriceRepo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public SaveDataService(IGoldPriceRepo goldPriceRepository,IConfiguration config,IMapper mapper)
        {
            _goldPriceRepo = goldPriceRepository;
            _config = config;
           _mapper = mapper;
        }

        public async Task<bool> SaveData(GoldPriceModel saveDataModel)
        {
            return (await SaveDataToDB(saveDataModel)&& await SaveDataToJsonFile(_mapper.Map<GoldPriceModel, GoldPriceJsonDto>(saveDataModel)));
           /* bool flag = await SaveDataToDB(saveDataModel);
            if (flag) flag = await SaveDataToJsonFile(_mapper.Map<GoldPriceModel, GoldPriceJsonDto>(saveDataModel));
            return flag;*/
        }

        public async Task<bool> SaveDataToDB(GoldPriceModel saveDataModel)
        {
            bool db = await _goldPriceRepo.SaveData(saveDataModel);
            return db;
        }

        public async Task<bool> SaveDataToJsonFile(GoldPriceJsonDto saveDataModel)
        {
            try
            {
                List<GoldPriceJsonDto> list = new List<GoldPriceJsonDto>();
                string fileName = this._config.GetSection("JSONfileName").Value;
                if (File.Exists(fileName))
                {
                    string json = await File.ReadAllTextAsync(fileName);
                    list = JsonSerializer.Deserialize<List<GoldPriceJsonDto>>(json) ?? new List<GoldPriceJsonDto>();
                }
                list.Add(saveDataModel);
                using (FileStream createStream = File.OpenWrite(this._config.GetSection("JSONfileName").Value))
                {
                    await JsonSerializer.SerializeAsync<List<GoldPriceJsonDto>>((Stream)createStream, list);
                    await createStream.DisposeAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
