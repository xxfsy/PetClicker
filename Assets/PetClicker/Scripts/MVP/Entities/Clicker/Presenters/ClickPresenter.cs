﻿using System;

public class ClickPresenter : BasePresenter, IClickablePresenter, IUsingSharedModelPresenter
{
    // т.к. Presenter обрабатывает клики с вида и изменяет модель, то логика обновления денег должна лежать тут, а модель должна просто меняться, а не содержать в себе логику изменения денег

    private IClickableModel _clickableModel => model as IClickableModel;

    private BaseSharedModel _moneySharedModel;

    public void SetSharedModel(BaseSharedModel sharedModel)
    {
        _moneySharedModel = sharedModel;
    }

    public void HandleClick()
    {
        UpdateModelAfterClick();
        UpdateSharedModel();
    }

    public void UpdateModelAfterClick()
    {
        int newValue = _clickableModel.ClicksValue;

        newValue++;

        _clickableModel?.SetNewValueAfterClick(newValue);
    }

    public void UpdateSharedModel()
    {
        if (_moneySharedModel is ICurrencySharedModel currencySharedModel)
        {
            int newValue = currencySharedModel.MoneyValue;

            newValue++;

            currencySharedModel.SetNewMoneyValue(newValue);
        }
        else
        {
            throw new NullReferenceException("SharedModel is not ICurrencySharedModel");
            //return;
        }
    }
}
