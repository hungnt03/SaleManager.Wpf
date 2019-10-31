﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleManager.Wpf.Results
{
    public abstract class ResultBase : IResult
    {
        public abstract void Execute(CoroutineExecutionContext context);

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        protected virtual void OnCompleted()
        {
            OnCompleted(new ResultCompletionEventArgs());
        }

        protected virtual void OnError(Exception error)
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                Error = error
            });
        }

        protected virtual void OnCancelled()
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                WasCancelled = true
            });
        }

        protected virtual void OnCompleted(ResultCompletionEventArgs e)
        {
            Caliburn.Micro.Execute.OnUIThread(() => Completed(this, e));
        }
    }
}