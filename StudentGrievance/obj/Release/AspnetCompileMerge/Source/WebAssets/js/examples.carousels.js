 
(function( $ ) {

	'use strict';

	/*
	Carousel
	*/
	$('#carousel').owlCarousel({
		loop: true,
		responsive: {
			0: {
				items: 1
			},
			479: {
				items: 1
			},
			768: {
				items: 2
			},
			979: {
				items: 3
			},
			1199: {
				items: 4
			}
		},
		navText: [],
		margin: 10,
		autoplay: true,
		autoplayTimeout: 2000,
		autoWidth: false,
		items: 6,
		rtl: ( $('html').attr('dir') == 'rtl' ) ? true : false
	});
	/*
	academic
	*/
	$('#acedmicdata').owlCarousel({
		loop: true,
		responsive: {
			0: {
				items: 1
			},
			479: {
				items: 1
			},
			768: {
				items: 2
			},
			979: {
				items: 2
			},
			1199: {
				items: 3
			}
		},
		navText: [],
		margin: 10,
		autoplay: true,
		autoplayTimeout: 2000,
		autoWidth: false,
		items: 3,
		rtl: ($('html').attr('dir') == 'rtl') ? true : false
	});


	/*
	Academic Event
	*/

	$('#academicevent').owlCarousel({
		loop: true,
		responsive: {
			0: {
				items: 1
			},
			479: {
				items: 1
			},
			768: {
				items: 2
			},
			979: {
				items: 2
			},
			1199: {
				items: 3
			}
		},
		navText: [],
		margin: 10,
		autoplay: true,
		autoplayTimeout: 2000,
		autoWidth: false,
		items: 3,
		rtl: ($('html').attr('dir') == 'rtl') ? true : false
	});



	/*
	Videos
	*/
	$('#videos').owlCarousel({
		items:2,
		loop:true,
		margin:10,
		video:true,
		lazyLoad:true,
		center:true,
		responsive:{
			480:{
				items:1
			},
			600:{
				items:2
			}
		},
		rtl: ( $('html').attr('dir') == 'rtl' ) ? true : false

	});

}).apply( this, [ jQuery ]);