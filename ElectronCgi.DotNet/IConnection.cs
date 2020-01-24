using System;

using System.IO;

using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
namespace ElectronCgi.DotNet
{
    public interface IConnection
    {
        bool IsLoggingEnabled { get; set; }

        LogLevel MinimumLogLevel { get; set; }

        string LogFilePath { get; set; }


        void On(string requestType, Action handler);

        void OnAsync<T>(string requestType, Func<T, Task> handler);

        void OnAsync(string requestType, Func<Task> handler);

        void On<T>(string requestType, Action<T> handler);

        void On<TIn, TOut>(string requestType, Func<TIn, TOut> handler);

        void OnAsync<TOut>(string requestType, Func<Task<TOut>> handler);

        void OnAsync<TIn, TOut>(string requestType, Func<TIn, Task<TOut>> handler);

        void Send(string requestType);

        void Send(string requestType, Action responseHandler);

        void SendAsync(string requestType, Func<Task> responseHandler);

        void Send<TRequestArgs>(string requestType, TRequestArgs args);

        void Send<TResponseArgs>(string requestType, Action<TResponseArgs> responseHandler);

        void SendAsync<TResponseArgs>(string requestType, Func<TResponseArgs, Task> responseHandlerAsync);

        void Send<TRequestArgs>(string requestType, TRequestArgs args, Action responseHandler);

        void SendAsync<TRequestArgs>(string requestType, TRequestArgs args, Func<Task> responseHandler);

        void Send<TRequestArgs, TResponseArgs>(string requestType, TRequestArgs args, Action<TResponseArgs> responseHandler);

        void SendAsync<TRequestArgs, TResponseArgs>(string requestType, TRequestArgs args, Func<TResponseArgs, Task> responseHandlerAsync);

        void Listen();

        void Start(Stream inputStream, TextWriter writer);

    }

}

