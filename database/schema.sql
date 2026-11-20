-- =====================================================================
-- CSIT321 Application Development - Part 6 Milestone
-- Project: GatherTable (Dining Event & Menu Coordinator)
-- Table: public.menu_items
-- =====================================================================

-- Drop table if it already exists to allow clean re-runs
drop table if exists public.menu_items cascade;

-- 1. Table design with Primary Key, check constraints and default values
create table public.menu_items (
  id bigint generated always as identity primary key,
  name text not null,
  description text not null default '',
  price numeric(10,2) not null default 0 check (price >= 0),
  category text not null default 'Main',
  image_url text not null default '',
  ingredients text not null default '',
  declared_allergens text not null default '',
  is_shared_dish boolean not null default false,
  default_shared_quantity integer not null default 1 check (default_shared_quantity >= 1),
  default_prep_note text not null default '',
  serving_note text not null default '',
  deleted_at timestamptz,                         -- for soft delete (Part IV & VI)
  created_at timestamptz not null default now()
);

-- 2. Fast Habits (Habit 1: Indexes on frequently filtered/searched columns)
create index on public.menu_items (name);
create index on public.menu_items (category);
create index on public.menu_items (deleted_at);

-- 3. Lock 1: GRANT permissions to anon role (public client access)
grant select, insert, update, delete on public.menu_items to anon;

-- 4. Lock 2: Row Level Security (RLS) policies
alter table public.menu_items enable row level security;

create policy "read_all"   on public.menu_items for select to anon using (true);
create policy "insert_all" on public.menu_items for insert to anon with check (true);
create policy "update_all" on public.menu_items for update to anon using (true) with check (true);
create policy "delete_all" on public.menu_items for delete to anon using (true);

-- 5. Initial Seed Data (Verified against GatherTable menu catalog)
insert into public.menu_items (
  name,
  description,
  price,
  category,
  image_url,
  ingredients,
  declared_allergens,
  is_shared_dish,
  default_shared_quantity,
  default_prep_note,
  serving_note
)
values
  (
    'Mushroom risotto',
    'Arborio rice, wild mushrooms, stock, Parmesan.',
    24.00,
    'Main',
    'https://images.unsplash.com/photo-1633964913295-ceb43826e7c9?w=600&auto=format&fit=crop&q=80',
    'Arborio rice, Wild mushrooms, Vegetable or chicken stock, Parmesan',
    'dairy',
    false,
    1,
    'Arborio rice, wild mushrooms, stock, Parmesan.',
    ''
  ),
  (
    'Herb-roasted chicken',
    'Roasted chicken, potatoes, herb jus.',
    28.00,
    'Main',
    'https://images.unsplash.com/photo-1598103442097-8b74394b95c6?w=600&auto=format&fit=crop&q=80',
    'Roasted chicken, Potatoes, Herb jus, Salt',
    'poultry',
    false,
    1,
    'Roasted chicken, potatoes, herb jus.',
    ''
  ),
  (
    'Citrus salmon',
    'Salmon, lemon, olive oil, dill, greens.',
    32.00,
    'Main',
    'https://images.unsplash.com/photo-1467003909585-2f8a72700288?w=600&auto=format&fit=crop&q=80',
    'Salmon, Lemon, Olive oil, Dill, Mixed greens, Dijon mustard, Salt',
    'fish, mustard',
    false,
    1,
    'Roasted salmon with lemon, dill, olive oil and dressed seasonal greens.',
    ''
  ),
  (
    'Roasted vegetables',
    'Seasonal carrots, squash, olive oil, herbs.',
    12.00,
    'SharedSide',
    'https://images.unsplash.com/photo-1540420773420-3366772f4999?w=600&auto=format&fit=crop&q=80',
    'Seasonal carrots, Squash, Olive oil, Fresh herbs',
    '',
    true,
    2,
    '',
    '2 bowls · Shared by all 6'
  ),
  (
    'Shrimp toast',
    'Crisp brioche, seasoned shrimp paste, scallions, sesame.',
    14.00,
    'Appetizer',
    'https://images.unsplash.com/photo-1541544741938-0af808871cc0?w=600&auto=format&fit=crop&q=80',
    'Crisp brioche, Shrimp paste, Scallions, Sesame, Ginger',
    'shellfish, sesame, gluten',
    false,
    1,
    'Crisp brioche toast with spiced shrimp paste.',
    ''
  );
