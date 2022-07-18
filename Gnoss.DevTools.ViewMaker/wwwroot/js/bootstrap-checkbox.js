(function(factory) {
    factory(jQuery);
})
(function($) {
  function create() {
    return $($.map(arguments, $.proxy(document, 'createElement')));
  }

  function Checkboxpicker(element, options) {
    this.element = element;
    this.$element = $(element);

    let data = this.$element.data();
    this.options = $.extend({}, $.fn.checkboxpicker.defaults, options, data);

    this.$group = create('div');

    this.$buttons = create('a', 'a');

    this.$off = this.$buttons.eq(1);
    this.$on = this.$buttons.eq(0);

    this.init();
  }

  Checkboxpicker.prototype = {
    init: function() {
      let fn = this.options.html ? 'html' : 'text';

      this.element.hidden = true;
      this.$group.addClass(this.options.baseGroupCls).addClass(this.options.groupCls);
      this.$buttons.addClass(this.options.baseCls).addClass(this.options.cls);

      this.$off[fn](this.options.offLabel);
      this.$on[fn](this.options.onLabel);

      if (this.element.checked) {
        this.$on.addClass('active');
        this.$on.addClass(this.options.onActiveCls);
        this.$off.addClass(this.options.offCls);
      } else {
        this.$off.addClass('active');
        this.$off.addClass(this.options.offActiveCls);
        this.$on.addClass(this.options.onCls);
      }

      this.$group.on('keydown', $.proxy(this, 'keydown'));
      this.$buttons.on('click', $.proxy(this, 'click'));
      this.$element.on('change', $.proxy(this, 'toggleChecked'));

      this.$group.append(this.$buttons).insertAfter(this.element);

	  this.$group.attr('tabindex', this.element.tabIndex);
    },
    toggleChecked: function() {
      this.$buttons.toggleClass('active');
      this.$off.toggleClass(this.options.offCls);
      this.$off.toggleClass(this.options.offActiveCls);
      this.$on.toggleClass(this.options.onCls);
      this.$on.toggleClass(this.options.onActiveCls);
    },
    click: function(event) {
      this.change();
    },
    change: function() {
      this.set(!this.element.checked);
    },
    set: function(value) {
      this.element.checked = value;
      this.$element.trigger('change');
    },
    keydown: function(event) {
      if ($.inArray(event.keyCode, this.options.toggleKeyCodes) !== -1) {
        event.preventDefault();
        this.change();
      } else if (event.keyCode === 13) {
        $(this.element.form).trigger('submit');
      }
    }
  };

  let old = $.fn.checkboxpicker;

  $.fn.checkboxpicker = function(options, elements) {
    let $elements;

    if (this instanceof $) {
      $elements = this;
    } else if (typeof options === 'string') {
      $elements = $(options);
    } else {
      $elements = $(elements);
    }

    return $elements.each(function() {
      let data = $.data(this, 'bs.checkbox');

      if (!data) {
        data = new Checkboxpicker(this, options);

        $.data(this, 'bs.checkbox', data);
      }
    });
  };

  $.fn.checkboxpicker.defaults = {
    baseGroupCls: 'btn-group',
    baseCls: 'btn',
    groupCls: null,
    cls: null,
    offCls: 'btn-default',
    onCls: 'btn-default',
    offActiveCls: 'btn-danger',
    onActiveCls: 'btn-success',
    offLabel: 'No',
    onLabel: 'Yes',
    iconCls: 'glyphicon',

    // Event key codes:
    // 13: Return
    // 32: Spacebar
    toggleKeyCodes: [13, 32],

  };

  $.fn.checkboxpicker.Constructor = Checkboxpicker;
  $.fn.checkboxpicker.noConflict = function() {
    $.fn.checkboxpicker = old;
    return this;
  };

  return $.fn.checkboxpicker;
});
