export const navItems = [
  {
    name: 'Dashboard',
    url: '/admin/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    name: 'Catalog',
    url: '/admin/catalog',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Products',
        url: '/admin/catalog/product',
        icon: 'icon-puzzle'
      },
      {
        name: 'Product Categories',
        url: '/admin/catalog/product-category',
        icon: 'icon-puzzle'
      },
      {
        name: 'Munafactures',
        url: '/admin/catalog/manufacture',
        icon: 'icon-puzzle'
      },
    ]
  },
  {
    name: 'Customers',
    url: '/admin/customer',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Customer',
        url: '/admin/customer/list',
        icon: 'icon-puzzle'
      },
      {
        name: 'Customer Roles',
        url: '/admin/customer/customer-role',
        icon: 'icon-puzzle'
      },
    ]
  },
  {
    name: 'Setting',
    url: '/admin/setting',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Warehouses',
        url: '/admin/setting/warehouse',
        icon: 'icon-puzzle'
      },
    ]
  },
];
