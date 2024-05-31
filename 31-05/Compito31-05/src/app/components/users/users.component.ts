import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user.model';
import { Todo } from '../../models/todo.model';
import { UserService } from '../../services/user.service';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent implements OnInit {
  users: User[] = [];
  todos: Todo[] = [];

  constructor(
    private userService: UserService,
    private todoService: TodoService
  ) {}

  ngOnInit(): void {
    this.users = this.userService.getUsers();
    this.todos = this.userService.getTodosForUsers();
  }

  getUserTodos(userId: number): Todo[] {
    return this.todos.filter((todo) => todo.userId === userId);
  }

  toggleTodoStatus(todo: Todo): void {
    todo.completed = !todo.completed;
    this.userService.updateTodoStatus(todo.id, todo.completed);
  }

  getRandomColor(): string {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }
}
