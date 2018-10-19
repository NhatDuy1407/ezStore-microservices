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
      // {
      //   name: 'Manufacturers',
      //   url: '/admin/manufacturer',
      //   icon: 'icon-puzzle'
      // },
      // {
      //   name: 'Product tags',
      //   url: '/admin/product-tag',
      //   icon: 'icon-puzzle'
      // },
      // {
      //   name: 'Attributes',
      //   icon: 'icon-puzzle',
      //   children: [
      //     {
      //       name: 'Product Attributes',
      //       url: '/admin/product-attribute',
      //       icon: 'icon-puzzle'
      //     },
      //     {
      //       name: 'Specification Attributes',
      //       url: '/admin/specification-attribute',
      //       icon: 'icon-puzzle'
      //     },
      //   ]
      // },
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
  }
];
