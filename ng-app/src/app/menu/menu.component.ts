import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Menu } from '../Models/Menu';
import { CommonModule } from '@angular/common';
import { MenuService } from '../Service/menu.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  menu: Menu[] = [];
  groupedMenu: { [key: string]: Menu[] } = {};
  selectedCategory: string="";

  constructor(private http: HttpClient, private menuService: MenuService, private route: ActivatedRoute){}

  ngOnInit() {
    this.getAll();
    this.route.paramMap.subscribe(params => {
      this.selectedCategory = params.get('category') || '';
      console.log("selected: ", this.selectedCategory);
      this.scrollToCategory();
    });
  }

  getAll() {
    this.menuService.getAll().subscribe(data => {
      this.menu = data;
      this.groupMenuByCategory(); // Veri alındıktan sonra gruplandır
    });
  }


  groupMenuByCategory() {
    this.groupedMenu = this.menu.reduce((groups, item) => {
      const category = item.categoryName;
      if (!groups[category]) {
        groups[category] = [];
      }
      groups[category].push(item);
      return groups;
    }, {} as { [key: string]: Menu[] });

  }

  scrollToCategory() {
    if (typeof document !== 'undefined') {
      const element = document.getElementById(this.selectedCategory);
    if (element) {
      const navbarHeight = 60;
      const elementPosition = element.getBoundingClientRect().top + window.pageYOffset;
      const offsetPosition = elementPosition - navbarHeight;

      window.scrollTo({
        top: offsetPosition,
        behavior: 'smooth'
      });
    }
    }
  }
}
