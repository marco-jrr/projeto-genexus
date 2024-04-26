function CharJS($)
{
	this.Width;
	this.Height;
	this.Type;
	this.graphData;
	this.Attribute;

	// Databinding for property graphData
	this.SetData = function(data)
	{
		///UserCodeRegionStart:[SetData] (do not remove this comment.)
		this.graphData = data;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property graphData
	this.GetData = function()
	{
		///UserCodeRegionStart:[GetData] (do not remove this comment.)
		return this.graphData;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Attribute
	this.SetAttribute = function(data)
	{
		///UserCodeRegionStart:[SetAttribute] (do not remove this comment.)


		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Attribute
	this.GetAttribute = function()
	{
		///UserCodeRegionStart:[GetAttribute] (do not remove this comment.)


		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function()
	{
		///UserCodeRegionStart:[show] (do not remove this comment.)

			var colorsBackground = [];
			colorsBackground.push('rgba(54, 162, 235, 0.4)');
			colorsBackground.push('rgba(255, 99, 132, 0.4)');			
			colorsBackground.push('rgba(255, 206, 86, 0.4)');
			colorsBackground.push('rgba(75, 192, 192, 0.4)');
			colorsBackground.push('rgba(153, 102, 255, 0.4)');
			colorsBackground.push('rgba(255, 159, 64, 0.4)');			
			colorsBackground.push('rgba(255, 206, 86, 0.2)');
			colorsBackground.push('rgba(75, 192, 192, 0.2)');
			colorsBackground.push('rgba(153, 102, 255, 0.2)');
			colorsBackground.push('rgba(255, 159, 64, 0.2)');
			colorsBackground.push('rgba(255, 99, 132, 0.2)');
			colorsBackground.push('rgba(54, 162, 235, 0.2)');			
			colorsBackground.push('rgba(255, 99, 132, 0.6)');
			colorsBackground.push('rgba(54, 162, 235, 0.6)');
			colorsBackground.push('rgba(255, 206, 86, 0.6)');
			colorsBackground.push('rgba(75, 192, 192, 0.6)');
			colorsBackground.push('rgba(153, 102, 255, 0.6)');
			colorsBackground.push('rgba(255, 159, 64, 0.6)');		
			colorsBackground.push('rgba(54, 162, 235, 0.4)');
			colorsBackground.push('rgba(255, 99, 132, 0.4)');			
			colorsBackground.push('rgba(255, 206, 86, 0.4)');
			colorsBackground.push('rgba(75, 192, 192, 0.4)');
			colorsBackground.push('rgba(153, 102, 255, 0.4)');
			colorsBackground.push('rgba(255, 159, 64, 0.4)');			
			colorsBackground.push('rgba(255, 206, 86, 0.2)');
			colorsBackground.push('rgba(75, 192, 192, 0.2)');
			colorsBackground.push('rgba(153, 102, 255, 0.2)');
			colorsBackground.push('rgba(153, 102, 255, 0.4)');
			colorsBackground.push('rgba(255, 159, 64, 0.4)');			
			colorsBackground.push('rgba(255, 206, 86, 0.2)');
			colorsBackground.push('rgba(75, 192, 192, 0.2)');
			colorsBackground.push('rgba(153, 102, 255, 0.2)');
			colorsBackground.push('rgba(255, 159, 64, 0.2)');
			colorsBackground.push('rgba(255, 99, 132, 0.2)');
			
			var colorsBorderColor = [];
			colorsBorderColor.push('rgba(54, 162, 235, 1)');
			colorsBorderColor.push('rgba(255,99, 132, 1)');
			colorsBorderColor.push('rgba(255, 206, 86, 1)');
			colorsBorderColor.push('rgba(75, 192, 192, 1)');
			colorsBorderColor.push('rgba(153, 102, 255, 1)');
			colorsBorderColor.push('rgba(255, 159, 64, 1)');
			colorsBorderColor.push('rgba(255,99, 132, 0.5)');
			colorsBorderColor.push('rgba(54, 162, 235, 0.5)');
			colorsBorderColor.push('rgba(255, 206, 86, 0.5)');
			colorsBorderColor.push('rgba(75, 192, 192, 0.5)');
			colorsBorderColor.push('rgba(153, 102, 255, 0.5)');
			colorsBorderColor.push('rgba(255, 159, 64, 0.5)');
			colorsBorderColor.push('rgba(255,99, 132, 0.8)');
			colorsBorderColor.push('rgba(54, 162, 235, 0.8)');
			colorsBorderColor.push('rgba(255, 206, 86, 0.8)');
			colorsBorderColor.push('rgba(75, 192, 192, 0.8)');
			colorsBorderColor.push('rgba(153, 102, 255, 0.8)');
			colorsBorderColor.push('rgba(255, 159, 64, 0.8)');			
			colorsBorderColor.push('rgba(255, 206, 86, 0.5)');
			colorsBorderColor.push('rgba(75, 192, 192, 0.5)');
			colorsBorderColor.push('rgba(153, 102, 255, 0.5)');
			colorsBorderColor.push('rgba(255, 159, 64, 0.5)');
			colorsBorderColor.push('rgba(255,99, 132, 0.8)');
			colorsBorderColor.push('rgba(54, 162, 235, 0.8)');
			colorsBorderColor.push('rgba(255, 206, 86, 0.8)');
			colorsBorderColor.push('rgba(75, 192, 192, 0.8)');
			colorsBorderColor.push('rgba(153, 102, 255, 0.8)');
			colorsBorderColor.push('rgba(255, 159, 64, 0.8)');		
			colorsBorderColor.push('rgba(255,99, 132, 1)');
			colorsBorderColor.push('rgba(255, 206, 86, 1)');
			colorsBorderColor.push('rgba(75, 192, 192, 1)');
			colorsBorderColor.push('rgba(153, 102, 255, 1)');
			colorsBorderColor.push('rgba(255, 159, 64, 1)');
			colorsBorderColor.push('rgba(255,99, 132, 0.5)');
			colorsBorderColor.push('rgba(54, 162, 235, 0.5)');			
			var idcanvas = this.ContainerName+"_canvas";
			//console.log(idcanvas);
			var buffer = '<div style="width:'+this.Width+'; height:'+this.Height+';">'+
						 '<canvas id="'+idcanvas+'" width="'+this.Width+'" height="'+this.Height+'"></canvas></div>';
			this.setHtml(buffer);
			var ctx = document.getElementById(idcanvas);

			var datagr = this.graphData;
			var data = datagr.data;
			var options = datagr.options;
			var tipo = this.Type;
			viewChart(ctx, tipo, data, options, colorsBackground, colorsBorderColor);	
	

		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)

	function viewChart(ctx, tipo, data, options, colorsBackground, colorsBorderColor){
 			
			var backgroundColor = [];
			var borderColor = [];
			for (x = 0; x < data.datasets.length; x++){
				if (data.datasets[x].backgroundColor != undefined){
					break;
				}
				data.datasets[x].backgroundColor = [];
				for (i = 0; i < data.datasets[x].data.length; i++) { 
					backgroundColor.push(colorsBackground[i]);
					borderColor.push(colorsBorderColor[i]);
				}
				data.datasets[x].backgroundColor = backgroundColor;	
				data.datasets[x].borderColor = borderColor;				
			}	
						
	 
		var graph = {
				type:  tipo,
				data: data,
				options: options,
				animation:{
					animateScale:true
				}
			};
		
		var myChart = new Chart(ctx, graph);
	}
	
	function getRandomColor() {
		var letters = '0123456789ABCDEF'.split('');
		var color = '#';
		for (var i = 0; i < 6; i++ ) {
			color += letters[Math.floor(Math.random() * 16)];
		}
		return color;
	}

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	///UserCodeRegionEnd: (do not remove this comment.):
}
