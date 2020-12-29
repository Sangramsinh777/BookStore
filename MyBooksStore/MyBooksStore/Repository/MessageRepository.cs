using Microsoft.Extensions.Options;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private IOptionsMonitor<NewBookConfig> _newBookConfig;
        public MessageRepository(IOptionsMonitor<NewBookConfig> newBookConfig)
        {
            _newBookConfig = newBookConfig;
            //newBookConfig.OnChange(config=> {
            //    _newBookConfig = config;
            //});
        }
        public string GetName()
        {
            return _newBookConfig.CurrentValue.BookName;
        }
    }
}
