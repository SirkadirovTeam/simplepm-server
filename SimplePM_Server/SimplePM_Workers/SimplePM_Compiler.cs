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

using System.IO;
using CompilerBase;
using System.Collections.Generic;

namespace SimplePM_Server
{

    /*
     * Класс компиляции  пользовательских  решений
     * задач по программированию. Функции в классе
     * вызывается функциями класса-официанта.
     */

    internal class SimplePM_Compiler
    {

        private readonly string _submissionId; // Идентификатор запроса
        private readonly string _fileLocation; // Полный путь к файлу и его расширение
        private dynamic _compilerConfig;
        private ICompilerPlugin _compilerPlugin; // Список загруженных модулей компиляторв
        
        public SimplePM_Compiler(
            ref dynamic _compilerConfig,
            ref ICompilerPlugin _compilerPlugin,
            string submissionId,
            string fileLocation
        )
        {
            
            // Проверяем путь к исходному коду на ошибки
            if (string.IsNullOrEmpty(fileLocation) || string.IsNullOrWhiteSpace(fileLocation) || !File.Exists(fileLocation))
                throw new FileNotFoundException("File not found!", fileLocation);

            /*
             * Присваиваем глобальным для класса переменным
             * значения локальных  переменных  конструктора
             * класса.
             */
            this._compilerConfig = _compilerConfig;
            this._compilerPlugin = _compilerPlugin;
            _submissionId = submissionId;
            _fileLocation = fileLocation;

        }
        
        public static ICompilerPlugin FindCompilerPlugin(
            ref List<ICompilerPlugin> _compilerPlugins,
            string pluginName
        )
        {

            /*
             * Производим поиск искомого плагина
             * в списке доступных модулей компиляции.
             */
            foreach (var plugin in _compilerPlugins)
                if (plugin.PluginName == pluginName)
                    return plugin;

            /*
             * Если по запросу  ничего не
             * найдено - возвращаем null.
             */
            return null;

        }

        /*
         * Метод производит поиск искомой
         * конфигурации модуля компиляции
         * пользовательских решений задач
         * по программированию и передаёт
         * ссылку на эту конфигурацию.
         *
         * Поиск специфической конфигурации
         * происходит   по   названию языка
         * программирования.
         */
        
        public static dynamic GetCompilerConfig(
            ref dynamic _compilerConfigs,
            string languageName
        )
        {

            /*
             * Производим перебор всех конфигураций компиляторов
             */
            foreach (var compilerConfig in _compilerConfigs)
            {

                /*
                 * Если текущая конфигурация является
                 * искомой, возвращаем ссылку на неё.
                 */
                if ((string)compilerConfig.language_name == languageName)
                    return compilerConfig;
                
                /*
                 * Иначе продолжаем поиск.
                 */

            }

            /*
             * Если соответствующий модуль компиляции
             * не найден, возвращаем значение null.
             */
            return null;

        }

        /*
         * Функция, которая по enum-у выбирает и
         * запускает определённый компилятор, а также
         * возвращает результат компиляции.
         */
        public CompilerResult ChooseCompilerAndRun()
        {
            
            /*
             * Выполняем   необходимые   действия  в
             * случае обнаружения нулевого возврата.
             */
            if (_compilerPlugin == null)
            {

                /*
                 * Возвращаем результат выполнения
                 * компиляции    пользовательского
                 * решения  поставленной   задачи,
                 * который сигнализирует о наличии
                 * ошибки,  которая  возникла  при
                 * попытке   поиска   необходимого
                 * модуля компиляции  для  данного
                 * скриптового  языка   или  языка
                 * программирования.
                 */
                return new CompilerResult
                {
                    HasErrors = true, // Хьюстон, у нас проблема!
                    CompilerMessage = "Language not supported by SimplePM!"
                };

            }

            /*
             * Возвращаем   ссылку  на  объект,
             * содержащий результаты компиляции
             * пользовательского        решения
             * поставленной задачи.
             */
            return _compilerPlugin.StartCompiler(
                ref _compilerConfig,
                _submissionId,
                _fileLocation
            );

        }

    }

}
