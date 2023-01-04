function GenerateBarChart(thongKes) {
	AmCharts.makeChart("chartdiv", {
		"type": "serial",
		"theme": "none",
		"categoryField": "name",
		"rotate": true,
		"startDuration": 1,
		"categoryAxis": {
			"gridPosition": "start",
			"position": "left"
		},
		"trendLines": [],
		"graphs": [
			{
				"balloonText": "Số Lượng:[[value]]",
				"fillAlphas": 0.8,
				"id": "AmGraph-1",
				"lineAlpha": 0.2,
				"title": "soLuong",
				"type": "column",
				"valueField": "soLuong"
			},
		],
		"guides": [],
		"valueAxes": [
			{
				"id": "ValueAxis-1",
				"position": "top",
				"axisAlpha": 0
			}
		],
		"allLabels": [],
		"balloon": {},
		"titles": [],
		"dataProvider": thongKes,
		"export": {
			"enabled": true
		}

	});
}