﻿using CoreDemo.Pages;
using EasyConsole;

namespace CoreDemo;

internal class DemoProgram : ConsoleBase
{
    public DemoProgram()
        : base("EasyConsole Demo", breadcrumbHeader: true)
    {
        AddPage(new MainPage(this));
        AddPage(new Page1(this));
        AddPage(new Page1A(this));
        AddPage(new Page1Ai(this));
        AddPage(new Page1B(this));
        AddPage(new Page2(this));
        AddPage(new InputPage(this));

        SetPage<MainPage>();
    }
}