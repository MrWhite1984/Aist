<h1>EMIS — Enterprise Management Information System для склада</h1>
Информационная система управления складским хозяйством на базе C# (.NET) и Microsoft SQL Server.
Автоматизирует учёт материалов, продукции, расходников, обработку заказов и формирование отчётов.
<h2>Основные возможности</h2>
<ul>
  <li>Учёт продуктов, материалов и расходников на складе</li>
  <li>Приём и учёт поставок от поставщиков</li>
  <li>Формирование и обработка заказов от магазинов</li>
  <li>Автоматическая генерация отчётов в формате .doc</li>
  <li>Разграничение доступа по ролям:</li>
  <ul>
    <li>Администратор</li>
    <li>Директор</li>
    <li>Кадровик</li>
    <li>Кладовщик магазина</li>
    <li>Кладовщик производства</li>
  </ul>
  <li>Защита данных через аутентификацию</li>
  <li>Поддержка CRUD-операций через удобный WinForms-интерфейс</li>
</ul>
<h2>Технологический стек</h2>
<table>
  <tr>
    <th>Компонент</th>
    <th>Технология</th>
  </tr>
  <tr>
    <td>Язык программирования</th>
    <td>C#</td>
  </tr>
  <tr>
    <td>GUI</td>
    <td>WinForms</td>
  </tr>
  <tr>
    <td>СУБД</td>
    <td>Microsoft SQL Server</td>
  </tr>
  <tr>
    <td>Отчеты</td>
    <td>Microsoft Word (.doc)</td>
  </tr>
</table>
<h2>Структура базы данных</h2>
Система включает 18 таблиц, охватывающих:
<ul>
  <li>Workers, Users — сотрудники и учётные записи</li>
  <li>Products, Materials, Consumables — номенклатура</li>
  <li>Stores, Order_from_the_store, Production_order_elements — заказы от магазинов</li>
  <li>Providers, Supplies, Conducted_supplies, Canceled_supplies — поставки</li>
  <li>Issue_of_materials, Issue_of_consumables — выдача ресурсов</li>
</ul>
Все связи реализованы через внешние ключи, обеспечена целостность данных.
<image src="git_img/db.png"></image>
<h2>Интерфейс</h2>
Форма аутентификации при запуске
<image src="git_img/UI1.png"></image>
Возможность фильтрации, добавления, редактирования и удаления записей
<em>Добавление работника</em>
<image src="git_img/UI2.png"></image>
<em>Фильтрация</em>
<image src="git_img/UI3.png"></image>
Создание отчета
<image src="git_img/UI4.png"></image>
