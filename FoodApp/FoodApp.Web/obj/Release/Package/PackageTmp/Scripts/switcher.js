init.push(function() {
    $('input[type="checkbox"]').switcher({
        theme: 'square',
        on_state_content: '<span class="fa fa-check"></span>',
        off_state_content: '<span class="fa fa-times"></span>'
    });

    // Colors
    $('#switchers-colors-default > input').switcher();
    $('#switchers-colors-square > input').switcher({ theme: 'square' });
    $('#switchers-colors-modern > input').switcher({ theme: 'modern' });

    // Sizes
    $('#switchers-sizes .switcher-example-default').switcher();
    $('#switchers-sizes .switcher-example-square').switcher({ theme: 'square' });
    $('#switchers-sizes .switcher-example-modern').switcher({ theme: 'modern' });

    // Disabled state
    $('#switcher-disabled-default').switcher();
    $('#switcher-disabled-square').switcher({ theme: 'square' });
    $('#switcher-disabled-modern').switcher({ theme: 'modern' });

    $('#switcher-enable-all').click(function() {
        $('#switchers-disabled input').switcher('enable');
    });

    $('#switcher-disable-all').click(function() {
        $('#switchers-disabled input').switcher('disable');
    });
});