﻿/*
 * ███████╗██╗███╗   ███╗██████╗ ██╗     ███████╗██████╗ ███╗   ███╗
 * ██╔════╝██║████╗ ████║██╔══██╗██║     ██╔════╝██╔══██╗████╗ ████║
 * ███████╗██║██╔████╔██║██████╔╝██║     █████╗  ██████╔╝██╔████╔██║
 * ╚════██║██║██║╚██╔╝██║██╔═══╝ ██║     ██╔══╝  ██╔═══╝ ██║╚██╔╝██║
 * ███████║██║██║ ╚═╝ ██║██║     ███████╗███████╗██║     ██║ ╚═╝ ██║
 * ╚══════╝╚═╝╚═╝     ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝     ╚═╝     ╚═╝
 *
 * SimplePM Server is a part of software product "Automated
 * verification system for programming tasks "SimplePM".
 *
 * Copyright 2018 Yurij Kadirov
 *
 * Source code of the product licensed under the Apache License,
 * Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Visit website for more details: https://spm.sirkadirov.com/
 */

using ProgramTestingAdditions;

namespace SimplePM_Server.ProgramTesting.SRunner
{
    
    public partial class ProgramExecutor
    {

        private SingleTestResult GenerateTestResult()
        {
            
            logger.Trace("ProgramExecutor for <" + _programPath + ">: GenerateTestResult() [started]");
            
            /*
             * Проверяем на наличие файла output.
             *
             * В случае если он существует, производим
             * чтение данных из него и представляем их
             * в виде выходных данных приложения.
             */
            
            // Генерируем результат тестирования программы
            var result = new SingleTestResult
            {

                // Выходные данные из стандартного потока
                ErrorOutput = _programErrorOutput,
                Output = ReadOutputData(),

                // Результаты предварительного тестирования
                ExitCode = _programProcess.ExitCode,
                Result = _testingResult,

                // Информация об использовании ресурсов
                UsedMemory = UsedMemory,
                UsedProcessorTime = UsedProcessorTime

            };
            
            /*
             * Освобождаем все связанные с процессом ресурсы.
             */

            _programProcess.Close();
            _programProcess.Dispose();

            logger.Trace("ProgramExecutor for <" + _programPath + ">: GenerateTestResult() [finished]");
            
            // Возвращаем сгенерированный результат
            return result;

        }

    }
    
}