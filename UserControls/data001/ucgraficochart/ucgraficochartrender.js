function UCGraficoChart($) {

	var template = '<div>  <canvas id=\"myChart\"></canvas></div><script src=\"https://cdn.jsdelivr.net/npm/chart.js\"></script><script>  const ctx = document.getElementById(\'myChart\');  new Chart(ctx, {    type: \'bar\',    data: {      labels: [\'Red\', \'Blue\', \'Yellow\', \'Green\', \'Purple\', \'Orange\'],      datasets: [{        label: \'# of Votes\',        data: [12, 19, 3, 5, 2, 3],        borderWidth: 1      }]    },    options: {      scales: {        y: {          beginAtZero: true        }      }    }  });</script>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts

	}

	this.Scripts = [];




	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}