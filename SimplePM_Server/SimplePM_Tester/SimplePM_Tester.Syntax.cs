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

using System.Text;
using ProgramTesting;

namespace SimplePM_Server.SimplePM_Tester
{
    
    internal partial class SimplePM_Tester
    {

        /*
         * Метод отвечает за выполнение проверки
         * синтаксиса пользовательского решения.
         */

        public ProgramTestingResult Syntax()
        {

            /*
             * Генерируем результат тестирования
             * и возвращаем его  как объект типа
             * ProgramTestingResult.
             */

            return new ProgramTestingResult(1)
            {

                TestingResults =
                {

                    [0] = new TestResult
                    {

                        // Выходные данные заполняем кракозябрами
                        Output = Encoding.UTF8.GetBytes("NULL"),

                        // Выходные данные исключений устанавливаем в null
                        ErrorOutput = null,

                        // Код выхода - стандартный
                        ExitCode = 0,

                        // Результатом будет промежуточный успешный
                        Result = TestResult.MiddleSuccessResult,

                        // Использованная память
                        UsedMemory = 0,

                        // Использованное процессорное время
                        UsedProcessorTime = 0

                    }

                }

            };

        }

    }

}