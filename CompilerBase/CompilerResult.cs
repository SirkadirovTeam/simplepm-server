﻿/*
 * Copyright (C) 2018, Yurij Kadirov.
 * All rights are reserved.
 * Licensed under Apache License 2.0 with additional restrictions.
 * 
 * @Author: Yurij Kadirov
 * @Website: https://spm.sirkadirov.com/
 * @Email: admin@sirkadirov.com
 * @Repo: https://github.com/SirkadirovTeam/SimplePM_Server
 */

namespace CompilerBase
{
    
    /*
     * Структура, которая позволяет хранить
     * информацию о результате компиляции
     * пользовательского решения поставленной
     * задачи по программированию.
     */

    public struct CompilerResult
    {

        // Поле указывает, возникли ли ошибки при компиляции
        // пользовательской программы
        public bool HasErrors;

        // Поле хранит полный путь к запускаемому файлу
        // пользовательского решения поставленной задачи
        public string ExeFullname;

        // Поле хранит выходной поток компилятора для
        // пользовательского решения поставленной задачи
        public string CompilerMessage;

    }

}
