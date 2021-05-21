# astronomy
__Название проекта:__ Собери Созвездия

__Команда:__ ПУШКА

__Формат системы:__ Мобильное приложение

__Цель проекта:__<br/>
Научить человека распознавать созвездия по рисунку.

__Описание:__<br/>
Расслабляющая, медитативная игра, строящаяся на визуале, где игрок сможет самостоятельно нарисовать созвездия, соединяя точки.

__Целевая аудитория:__<br/>
Люди 9 - 12 лет из СНГ.

__Основное преимущество:__
Визуальная составляющая, удобство и понятность игрового процесса.

__Стек технологий:__ c#, Unity.

__Сценарий использования:__

1. Игрок выбирает уровень.<br/>
2. Соединяет точки, используя кнопку подсказки.<br/>
3. При неудачной отрисовке созвездия удаляет ненужные линии, либо пробует пройти уровень заново через экран паузы.<br/>
4. При правильном рисунке появляется анимированный зверек и кнопка с коротким рассказом.<br/>
5. Игрок переходит к экрану похвалы, через который попадает на следующий уровень, переходит в меню или начинает уровень заново.
  
__Основные требования к ПО для пользования:__
ОС Android

__Порядок установки:__

1. Переместить файлы из репозитория на компьютер в виде zip архива.<br/>
2. Распаковать архив.<br/>
3. Открыть сцену меню с помощью Unity.<br/>
4. Запустить игру.<br/>

__Структура приложения:__
1. astronomy/astronomy/Assets/Animation/ - директория, содержащая анимацию медиа-данные (анимации).<br/>
2. astronomy/astronomy/Assets/Scripts/ - директория, содержащая скрипты.<br/>
3. astronomy/astronomy/Assets/Scenes/ - директория, содержащая сцены игры. <br/>
4. astronomy/astronomy/Assets/Scripts/ConnectCircles.cs - скрипт, отвечающий за соединение точек. <br/>
5. astronomy/astronomy/Assets/Scripts/DeleteLines.cs - скрипт, отвечающий за удаление линий в игре.<br/>
6. astronomy/astronomy/Assets/Scripts/Scene.cs - скрипт, отвечающий за загрузку сцены уровня через меню.<br/>
