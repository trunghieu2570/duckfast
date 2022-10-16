﻿/* globals Chart:false, feather:false */

(function () {
    'use strict'

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })

    feather.replace({ 'aria-hidden': 'true' })
})()