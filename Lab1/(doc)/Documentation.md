# Лабораторная работа №1
## Приложение разработано по условию Лабораторной работы №1, на языке C#, в приложении Microsoft Visual Studio 2022 Community Edition

### В приложении реализовано:
* Палитра, позволяющая выбирать цвет (по нажатию):
    - С помощью стандартного **PictureBox** (Windows Forms).
* Слайдеры, позволяющие менять цвет:
    - С помощью стандартных элементов управления **TrackBar** (Windows Forms).
* Ввода численных значений цвета:
    - С помощью стандартных элементов управления **NumericUpDown** (Windows Forms).
* Поле, отображающее выбранный цвет:
    - С помощью стандартного **Label** (Windows Forms).

### В приложении разработаны методы:
* **colorChange**:
    - Изменяет цвет поля на выбранный.
* **"цветовая модель"ValuesChange**:
    - Изменяет значения **TrackBar** и **NumericUpDown** цветовой модели.
* **"цветовая модель"ValuesChangedEvent**:
    - При изменении значений цветовой модели, осуществляет перевод и вызывает методы **"цветовая модель"ValuesChange()** для других цветовых моделей, а также **colorChange()**.

### Библиотеки:
* **ColorHelper**
    - Стороння библиотека с уже написанными формулами перевода, использованная для уменьшения громоздкости кода и во избежание его множественного повторения.
