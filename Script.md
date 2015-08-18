# Javascript for Default.aspx #

```
/*
Method	Return Type	Description
draw(data, options)	none	Draws the chart. You can speed up response time for the second and later calls to draw() by using the allowRedraw property.
getSelection()	Array of selection elements	Standard getSelection() implementation. Selected elements are cell elements. Only one cell can be selected at a time by the user.
getVisibleChartRange()	An object with start and end properties	Returns an object with start and end properties, which each one of them is a Date object, representing the current time selection.
hideDataColumns(columnIndexes)	none	Hides the specified data series from the chart. Accepts one parameter which can be a number or an array of numbers, in which 0 refers to the first data series, and so on.
setVisibleChartRange(start, end)	none	Sets the visible range (zoom) to the specified range. Accepts two parameters of type Date that represent the first and last times of the wanted selected visible range. Set start to null to include everything from the earliest date to end; set end to null to include everything from start to the last date.
showDataColumns(columnIndexes)	none	Shows the specified data series from the chart, after they were hidden using hideDataColumns method. Accepts one parameter which can be a number or an array of numbers, in which 0 refers to the first data series, and so on.
*/
function MyTimeLineSelectHandler(chart,a,b,c)
{
    alert('You selected ' + chart.getSelection());
}    
function MyTimeLineRangeChange(chart,a,b,c)
{
    alert('Range Change'); 
}

/*

Method	Return Type	Description
draw(data, options)	none	 Draws the chart. The chart accepts further method calls only after the ready event is fired. Extended description.
getSelection()	Array of selection elements	 Returns an array of the selected chart entities. Selectable entities are points, annotations, legend entries and categories. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null). For this chart, only one entity can be selected at any given moment. Extended description.
setSelection()	none	 Selects the specified chart entities. Cancels any previous selection. Selectable entities are points, annotations, legend entries and categories. A point or annotation correlates to a cell in the data table, a legend entry to a column (row index is null), and a category to a row (column index is null). For this chart, only one entity can be selected at a time. Extended description.
clearChart()	none	 Clears the chart, and releases all of its allocated resources.
*/
function MyAreaChartSelectHandler(chart,a,b,c)
{
    var sel = chart.getSelection();
    var el = document.getElementById('AreaShowMouseOver');
    el.innerHTML = 'You selected: ' + sel[0].column +  ',' + sel[0].row
}


/*
    Apply the formatter to the chart data or anything else, its my hook into GoogleVisualizations
      data.setCell(4, 0, 'Mike');
      data.setCell(4, 1, 12000);
      data.setCell(4, 2, false);

              var formatter = new google.visualization.NumberFormat({prefix: '$'});
              formatter.format(data, 1); // Apply formatter to second column

      var view = new google.visualization.DataView(data);
      view.setColumns([0, 1]);

*/
function MyColumnChartDataFormatter(chart,data)
{
    var formatter = new google.visualization.NumberFormat({prefix: '$'});
     formatter.format(data, 2); // Apply formatter to second column
     formatter.format(data, 1); // Apply formatter to second column
}
```